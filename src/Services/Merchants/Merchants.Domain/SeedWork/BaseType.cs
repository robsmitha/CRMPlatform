using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Merchants.Domain.SeedWork
{
    public class BaseType<E> : BaseEntity where E : Enum
    {
        public string Name { get; set; }
        public string Description { get; set; }
        protected BaseType() { }
        protected BaseType(E @enum)
        {
            ID = @enum.EnumToInt();
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }
    }

    public static class BaseTypeExtensions
    {
        public static int EnumToInt<TValue>(this TValue value) where TValue : Enum
            => (int)(object)value;

        public static string GetEnumDescription<TEnum>(this TEnum item)
       => item.GetType()
              .GetField(item.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .Cast<DescriptionAttribute>()
              .FirstOrDefault()?.Description ?? string.Empty;

        public static void SeedEnumValues<T, TEnum>(this DbSet<T> dbSet, Func<TEnum, T> converter)
            where T : class => Enum.GetValues(typeof(TEnum))
                                   .Cast<object>()
                                   .Select(value => converter((TEnum)value))
                                   .ToList()
                                   .ForEach(instance => dbSet.Add(instance));
    }
}
