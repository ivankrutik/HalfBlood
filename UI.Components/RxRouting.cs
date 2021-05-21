﻿namespace UI.Components
{
    using System;
    using System.Linq;
    using global::ReactiveUI;

    public static class RxRouting
    {
        public static Func<string, string> ViewModelToViewFunc { get; set; }

        static RxRouting()
        {
            ViewModelToViewFunc = (vm) => interfaceifyTypeName(vm.Replace("ViewModel", "View"));
        }

        /// <summary>
        /// Returns the View associated with a ViewModel, deriving the name of
        /// the Type via ViewModelToViewFunc, then discovering it via
        /// ServiceLocator.
        /// </summary>
        /// <param name="viewModel">The ViewModel for which to find the
        /// associated View.</param>
        /// <returns>The View for the ViewModel.</returns>
        public static IViewFor ResolveView<T>(T viewModel)
            where T : class
        {
            // Given IFooBarViewModel (whose name we derive from T), we'll look 
            // for a few things:
            // * IFooBarView that implements IViewFor
            // * IViewFor<IFooBarViewModel>
            // * IViewFor<FooBarViewModel> (the original behavior in RxUI 3.1)

            var attrs = viewModel.GetType().GetCustomAttributes(typeof(ViewContractAttribute), true);
            string key = null;

            if (attrs.Any())
            {
                key = ((ViewContractAttribute)attrs.First()).Contract;
            }

            // IFooBarView that implements IViewFor (or custom ViewModelToViewFunc)
            var typeToFind = ViewModelToViewFunc(viewModel.GetType().AssemblyQualifiedName);
            try
            {
                var type = Reflection.ReallyFindType(typeToFind, true);

                var ret = RxApp.DependencyResolver.GetService(type, key) as IViewFor;
                if (ret != null) return ret;
            }
            catch (Exception ex)
            {
                LogHost.Default.DebugException("Couldn't instantiate " + typeToFind, ex);
            }

            var viewType = typeof(IViewFor<>);

            // IViewFor<IFooBarViewModel>
            try
            {
                var ifn = interfaceifyTypeName(viewModel.GetType());
                var type = Reflection.ReallyFindType(ifn, true);
                var ret = RxApp.DependencyResolver.GetService(viewType.MakeGenericType(type), key) as IViewFor;
                if (ret != null) return ret;
            }
            catch (Exception ex)
            {
                LogHost.Default.DebugException("Couldn't instantiate View via pure interface type", ex);
            }

            // IViewFor<FooBarViewModel> (the original behavior in RxUI 3.1)
            return (IViewFor)RxApp.DependencyResolver.GetService(viewType.MakeGenericType(viewModel.GetType()), key);
        }

        static string interfaceifyTypeName(string typeName)
        {
            var typeVsAssembly = typeName.Split(',');
            var parts = typeVsAssembly[0].Split('.');
            parts[parts.Length - 1] = "I" + parts[parts.Length - 1];

            var newType = String.Join(".", parts, 0, parts.Length);
            return newType + "," + String.Join(",", typeVsAssembly.Skip(1));
        }

        static string interfaceifyTypeName(Type type)
        {
            return type.GetInterface(string.Format("I{0}", type.Name))
                .AssemblyQualifiedName;
        }
    }
}
