using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Buisness.Entities.TestSheetDomain;
using Halfblood.Common;

namespace UI.ProcessComponents.TestSheetsDomain
{
    public class TestSheetsHelper
    {
        public enum GroupFunc
        {
            Average = 1,
            Max = 2,
            Min = 3
        }

        public static long GetNextNumber(IEnumerable<IHasRowNumber> list)
        {
            if (list == null) return 1;
            IHasRowNumber lastOrDefault = list.LastOrDefault();
            return lastOrDefault == null ? 1 : lastOrDefault.Number + 1;
        }

        // попытка получить следующее значение из списка указанного поля
        public static string TryGetNextFieldValue(IEnumerable<IDto> list, string field)
        {
            if (list == null) return "1";
            if (!list.Any()) return "1";
            // если не указано поле - ошибка
            if (string.IsNullOrEmpty(field)) throw new ArgumentException("TryGetNextFieldValue: field is empty");
            // если указано поле
            return list.Max(dto =>
            {
                int res;
                object value = dto.GetType().GetProperty(field).GetValue(dto);
                if (value != null)
                    if (int.TryParse(value.ToString(), out res)) return (++res);
                return 1;
            }).ToString(CultureInfo.InvariantCulture);
        }

        public static void FillRowNumbers(IList list)
        {
            if (list != null)
                for (int i = 0; i < list.Count; i++) ((IHasRowNumber) list[i]).Number = i + 1;
        }

        public static SampleResultSetDto CreateSampleResultsItemByGroupFunc(IList<SampleResultSetDto> sampleResultSets,
            GroupFunc func)
        {
            var item = new SampleResultSetDto {IsRow = true};
            switch (func)
            {
                case GroupFunc.Average: item.Title = "Сред.балл"; break;
                case GroupFunc.Max: item.Title = "Макс.балл"; break;
                case GroupFunc.Min: item.Title = "Мин.балл"; break;
                default: throw new ArgumentOutOfRangeException("func");
            }
            SampleResultSetDto[] query = sampleResultSets.Where(row => row.IsRow &&
                                                                       !(row.Title.ToLower().Contains("макс.") ||
                                                                         row.Title.ToLower().Contains("мин.") ||
                                                                         row.Title.ToLower().Contains("сред."))).ToArray();
            for (int i = 1; i < 11; i++)
            {
                string field = "Value" + i;
                if (!string.IsNullOrEmpty(sampleResultSets.Aggregate(string.Empty, (current, x) => current + GetValue(x, field))))
                {
                    double result;
                    switch (func)
                    {
                        case GroupFunc.Average: result = query.Average(row => SafeParse(row, field)); break;
                        case GroupFunc.Max: result = query.Max(row => SafeParse(row, field)); break;
                        case GroupFunc.Min: result = query.Min(row => SafeParse(row, field)); break;
                        default: throw new ArgumentOutOfRangeException("func");
                    }
                    item.GetType().GetProperty(field).SetValue(item, result.ToString(CultureInfo.InvariantCulture));
                }
            }
            return item;
        }

        private static string GetValue(SampleResultSetDto dto, string field)
        {
            object value = dto.GetType().GetProperty(field).GetValue(dto);
            return value == null ? string.Empty : value.ToString();
        }

        private static double SafeParse(SampleResultSetDto dto, string field)
        {
            object value = dto.GetType().GetProperty(field).GetValue(dto);
            if (value == null) return 0.0;
            double res;
            if (double.TryParse(value.ToString(), out res))
                return res;
            return 0.0;
        }
    }
}