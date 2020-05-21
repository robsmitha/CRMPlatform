using AutoMapper;
using Google.Protobuf.Collections;
using Merchants.API.Application.Common.Mappings;
using Merchants.Domain.Aggregates.OrganizationAggregate;
using System.Collections.Generic;
using System.Text;

namespace Merchants.API.Application.Queries.SearchMerchants
{
    public class SearchMerchantModel : IMapFrom<Merchant>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CallToAction { get; set; }
        public string ShortDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string StateAbbreviation { get; set; }
        public string Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int MerchantTypeID { get; set; }
        public string MerchantTypeName { get; set; }
        public string DefaultImageUrl { get; set; }
        public double? MilesAway { get; set; }
        public string DistanceAway
        {
            get
            {
                if (MilesAway == null) return string.Empty;

                //todo: globalization
                return $"{MilesAway:0.0} Miles away";
            }
        }
        public string Location
        {
            get
            {
                var fields = new[] { Street1, Street2, City, StateAbbreviation, Zip };
                var sb = new StringBuilder();
                for (var i = 0; i < fields.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(fields[i]))
                        continue;

                    sb.Append($"{fields[i]}, ");
                }
                var location = sb.ToString().Trim();
                return location.EndsWith(",")
                    ? location[0..^1]
                    : location;
            }
        }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Merchant, SearchMerchantModel>();

        //    profile.CreateMap<Merchant, GrpcMerchants.SearchMerchantModel>();
        //    profile.CreateMap(typeof(IEnumerable<>), typeof(RepeatedField<>)).ConvertUsing(typeof(EnumerableToRepeatedFieldTypeConverter<,>));
        //    profile.CreateMap(typeof(RepeatedField<>), typeof(List<>)).ConvertUsing(typeof(RepeatedFieldToListTypeConverter<,>));
        //}
        private class EnumerableToRepeatedFieldTypeConverter<TITemSource, TITemDest> : ITypeConverter<IEnumerable<TITemSource>, RepeatedField<TITemDest>>
        {
            public RepeatedField<TITemDest> Convert(IEnumerable<TITemSource> source, RepeatedField<TITemDest> destination, ResolutionContext context)
            {
                destination = destination ?? new RepeatedField<TITemDest>();
                foreach (var item in source)
                {
                    destination.Add(context.Mapper.Map<TITemDest>(item));
                }
                return destination;
            }
        }

        private class RepeatedFieldToListTypeConverter<TITemSource, TITemDest> : ITypeConverter<RepeatedField<TITemSource>, List<TITemDest>>
        {
            public List<TITemDest> Convert(RepeatedField<TITemSource> source, List<TITemDest> destination, ResolutionContext context)
            {
                destination = destination ?? new List<TITemDest>();
                foreach (var item in source)
                {
                    destination.Add(context.Mapper.Map<TITemDest>(item));
                }
                return destination;
            }
        }
    }
}
