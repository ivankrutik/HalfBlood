// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyContext.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The copy context view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using ReactiveUI;

    /// <summary>
    /// The copy context.
    /// </summary>
    /// <typeparam name="T">
    /// The type must be mark attribute Serializer
    /// </typeparam>
    public class CopyContext<T> : INotifyPropertyChanged
    {
        private T _sourceValue;
        private T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyContext{T}"/> class.
        /// </summary>
        public CopyContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyContext{T}"/> class.
        /// </summary>
        /// <param name="instance">
        /// The instance.
        /// </param>
        public CopyContext(T instance)
        {
            this.SetSourceValue(instance);
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the _value.
        /// </summary>
        public T Value
        {
            get { return this._value; }
            private set
            {
                this._value = value;
                this.OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// The set source _value.
        /// </summary>
        /// <param name="instance">
        /// The instance.
        /// </param>
        public void SetSourceValue(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            _sourceValue = instance;

            var contractResolver = new SisoJsonDefaultContractResolver();
            var settings = new JsonSerializerSettings
                               {
                                   ContractResolver = contractResolver,
                                   ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                                   PreserveReferencesHandling = PreserveReferencesHandling.All,
                                   TypeNameHandling = TypeNameHandling.Objects,
                                   Converters = { new ImageConverter() }
                               };

            string json = JsonConvert.SerializeObject(_sourceValue, settings);
            var buffer = JsonConvert.DeserializeObject<T>(json, settings);

            if (_sourceValue is IList)
            {
                Value = (T)((IList)buffer).CreateGenericCollection(typeof(ReactiveList<>), buffer);
                return;
            }

            Value = buffer;
        }

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            if (_sourceValue is IList)
            {
                ((IList)_sourceValue).Clear();
                foreach (var item in ((IList)Value))
                {
                    ((IList)_sourceValue).Add(item);
                }

                return;
            }

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties().Where(x => x.CanWrite))
            {
                propertyInfo.SetValue(_sourceValue, propertyInfo.GetValue(Value, null), null);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private class SisoJsonDefaultContractResolver : DefaultContractResolver
        {
            protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
            {
                return new CustomValueProvider(member);
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);

                if (!prop.Writable)
                {
                    var property = member as PropertyInfo;
                    if (property != null)
                    {
                        var hasPrivateSetter = property.GetSetMethod(true) != null;
                        prop.Writable = hasPrivateSetter;
                    }
                }

                return prop;
            }
        }
        private class CustomValueProvider : IValueProvider
        {
            private readonly MemberInfo _memberInfo;

            public CustomValueProvider(MemberInfo memberInfo)
            {
                _memberInfo = memberInfo;
            }

            public void SetValue(object target, object value)
            {
                if ((value is IList) && !(value is Array))
                {
                    value = ((IList)value).CreateGenericCollection(typeof(ReactiveList<>), value);
                }

                switch (_memberInfo.MemberType)
                {
                    case MemberTypes.Field:
                        ((FieldInfo)_memberInfo).SetValue(target, value);
                        break;
                    case MemberTypes.Property:
                        ((PropertyInfo)_memberInfo).SetValue(target, value, (object[])null);
                        break;
                    default:
                        throw new ArgumentException(
                            "MemberInfo '{0}' must be of type FieldInfo or PropertyInfo",
                            _memberInfo.Name);
                }
            }

            public object GetValue(object target)
            {
                switch (_memberInfo.MemberType)
                {
                    case MemberTypes.Field:
                        return ((FieldInfo)_memberInfo).GetValue(target);
                    case MemberTypes.Property:
                        try
                        {
                            return ((PropertyInfo)_memberInfo).GetValue(target, (object[])null);
                        }
                        catch (TargetParameterCountException ex)
                        {
                            throw new ArgumentException(
                                "MemberInfo '{0}' has index parameters. {1}",
                                _memberInfo.Name,
                                ex);
                        }
                    default:
                        throw new ArgumentException(
                            "MemberInfo '{0}' is not of type FieldInfo or PropertyInfo",
                            _memberInfo.Name);
                }
            }
        }
        private class ImageConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Bitmap);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return null;
                //                var m = new MemoryStream(Convert.FromBase64String((string)reader.Value));
                //                return (Bitmap)Bitmap.FromStream(m);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(string.Empty);

                //                var bmp = (Bitmap)value;
                //                var m = new MemoryStream();
                //                bmp.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                //
                //                writer.WriteValue(Convert.ToBase64String(m.ToArray()));
            }
        }
    }
}
