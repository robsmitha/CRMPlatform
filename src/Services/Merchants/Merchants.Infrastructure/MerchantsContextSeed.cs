using Merchants.Domain.Aggregates.OrganizationAggregate;
using Merchants.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.Infrastructure
{
    public class MerchantsContextSeed
    {
        public static async Task Seed(MerchantsContext context, IOptions<MerchantSettings> settings, ILogger<MerchantsContextSeed> logger)
        {
            if (context.Organizations.FirstOrDefault() != null) return;

            //TODO: Configure json file for dynamic system startup data

            #region Test Organizations
            //add test organizations
            var testOrganization1 = new Organization
            {
                Name = "Five Star Cleaners, LLC.",
                Description = "Five Star Cleaners, LLC. organization record for group all merchants owned by this organization."
            };
            var testOrganization2 = new Organization
            {
                Name = "Easy Street Cleaners, LLC.",
                Description = "Five Star Cleaners, LLC. organization record for group all merchants owned by this organization."
            };
            var testOrganization3 = new Organization
            {
                Name = "Lucky Charm Cleaners, LLC.",
                Description = "Lucky Charm Cleaners, LLC. organization record for group all merchants owned by this organization."
            };
            var testOrganization4 = new Organization
            {
                Name = "Unicorn Cleaners, LLC.",
                Description = "Unicorn Cleaners, LLC. organization record for group all merchants owned by this organization."
            };
            context.Organizations.Add(testOrganization1);
            context.Organizations.Add(testOrganization2);
            context.Organizations.Add(testOrganization3);
            context.Organizations.Add(testOrganization4);
            #endregion

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = context.Database.BeginTransaction();
                context.MerchantTypes.SeedEnumValues<MerchantType, MerchantTypeEnum>(@enum => @enum);
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT merchants.MerchantTypes ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT merchants.MerchantTypes OFF");
                transaction.Commit();
            });

            await context.SaveChangesAsync();

            #region Test Merchants
            //add test merchants
            var testOrganization1Merchant1 = new Merchant
            {
                MerchantTypeID = (int)MerchantTypeEnum.DryCleaners,
                Name = "Five Star Cleaners",
                Description = "We know you are on the go and it is not easy to handle all of your day to day chores without feeling stressed! Errands are a part of life but what if you could free up this time in your routine? We can help! Let us show you our first class dry cleaning and laundry services and you'll see why we are the best laundry service around. We have been in the biz since 1994 and we know our stuff. You can trust the professionals to take care of your laundry services. Try us out today and see for yourself!",
                WebsiteUrl = "robsmitha.com",
                CallToAction = "Once you try our services, you will love the newfound free time in your routine - we guarantee it!",
                ShortDescription = "No other laundry service can even come close to impressing you like ours.",
                OrganizationID = testOrganization1.ID,
                City = "Tampa",
                StateAbbreviation = "FL",
                Latitude = 27.950575,
                Longitude = -82.457176,
                Phone = "(123) 456-7890",
                ContactEmail = "name@example.com",
                OperatingHours = "Monday - Friday: 9:00 AM to 5:00 PM",
            };
            var testOrganization1Merchant2 = new Merchant
            {
                MerchantTypeID = (int)MerchantTypeEnum.DryCleaners,
                Name = "Five Star Cleaners",
                Description = "We know you are on the go and it is not easy to handle all of your day to day chores without feeling stressed! Errands are a part of life but what if you could free up this time in your routine? We can help! Let us show you our first class dry cleaning and laundry services and you'll see why we are the best laundry service around. We have been in the biz since 1994 and we know our stuff. You can trust the professionals to take care of your laundry services. Try us out today and see for yourself!",
                WebsiteUrl = "robsmitha.com",
                CallToAction = "Once you try our services, you will love the newfound free time in your routine - we guarantee it!",
                ShortDescription = "No other laundry service can even come close to impressing you like ours.",
                OrganizationID = testOrganization1.ID,
                City = "Tallahassee",
                StateAbbreviation = "FL",
                Latitude = 30.455000,
                Longitude = -84.253334,
                Phone = "(123) 456-7890",
                ContactEmail = "name@example.com",
                OperatingHours = "Monday - Friday: 9:00 AM to 5:00 PM",
                IsDefault = true
            };

            var testOrganization2Merchant1 = new Merchant
            {
                MerchantTypeID = (int)MerchantTypeEnum.DryCleaners,
                Name = "Easy Street Cleaners",
                Description = "We know you are on the go and it is not easy to handle all of your day to day chores without feeling stressed! Errands are a part of life but what if you could free up this time in your routine? We can help! Let us show you our first class dry cleaning and laundry services and you'll see why we are the best laundry service around. We have been in the biz since 1994 and we know our stuff. You can trust the professionals to take care of your laundry services. Try us out today and see for yourself!",
                WebsiteUrl = "robsmitha.com",
                CallToAction = "Once you try our services, you will love the newfound free time in your routine - we guarantee it!",
                ShortDescription = "Our services use environment friendly products so you can feel good about your impact.",
                OrganizationID = testOrganization2.ID,
                City = "Tallahassee",
                StateAbbreviation = "FL",
                Latitude = 30.455000,
                Longitude = -84.253334,
                Phone = "(123) 456-7890",
                ContactEmail = "name@example.com",
                OperatingHours = "Monday - Friday: 9:00 AM to 5:00 PM",
                IsDefault = true
            };
            var testOrganization2Merchant2 = new Merchant
            {
                MerchantTypeID = (int)MerchantTypeEnum.DryCleaners,
                Name = "Easy Street Cleaners",
                Description = "We know you are on the go and it is not easy to handle all of your day to day chores without feeling stressed! Errands are a part of life but what if you could free up this time in your routine? We can help! Let us show you our first class dry cleaning and laundry services and you'll see why we are the best laundry service around. We have been in the biz since 1994 and we know our stuff. You can trust the professionals to take care of your laundry services. Try us out today and see for yourself!",
                WebsiteUrl = "robsmitha.com",
                CallToAction = "Once you try our services, you will love the newfound free time in your routine - we guarantee it!",
                ShortDescription = "Our services use environment friendly products so you can feel good about your impact.",
                OrganizationID = testOrganization2.ID,
                City = "New York",
                StateAbbreviation = "NY",
                Latitude = 40.712776,
                Longitude = -74.005974,
                Phone = "(123) 456-7890",
                ContactEmail = "name@example.com",
                OperatingHours = "Monday - Friday: 9:00 AM to 5:00 PM",
            };

            var testOrganization3Merchant1 = new Merchant
            {
                MerchantTypeID = (int)MerchantTypeEnum.DryCleaners,
                Name = "Lucky Charm Cleaners",
                Description = "We know you are on the go and it is not easy to handle all of your day to day chores without feeling stressed! Errands are a part of life but what if you could free up this time in your routine? We can help! Let us show you our first class dry cleaning and laundry services and you'll see why we are the best laundry service around. We have been in the biz since 1994 and we know our stuff. You can trust the professionals to take care of your laundry services. Try us out today and see for yourself!",
                WebsiteUrl = "robsmitha.com",
                CallToAction = "Once you try our services, you will love the newfound free time in your routine - we guarantee it!",
                ShortDescription = "We'll be your good luck charm!",
                OrganizationID = testOrganization3.ID,
                City = "Beverly Hills",
                StateAbbreviation = "CA",
                Latitude = 34.077200,
                Longitude = -118.422450,
                Phone = "(123) 456-7890",
                ContactEmail = "name@example.com",
                OperatingHours = "Monday - Friday: 9:00 AM to 5:00 PM",
                IsDefault = true
            };

            var testOrganization4Merchant1 = new Merchant
            {
                MerchantTypeID = (int)MerchantTypeEnum.DryCleaners,
                Name = "Unicorn Cleaners",
                Description = "We know you are on the go and it is not easy to handle all of your day to day chores without feeling stressed! Errands are a part of life but what if you could free up this time in your routine? We can help! Let us show you our first class dry cleaning and laundry services and you'll see why we are the best laundry service around. We have been in the biz since 1994 and we know our stuff. You can trust the professionals to take care of your laundry services. Try us out today and see for yourself!",
                WebsiteUrl = "robsmitha.com",
                CallToAction = "Once you try our services, you will love the newfound free time in your routine - we guarantee it!",
                ShortDescription = "A truly amazing cleaners with awesome Google reviews.",
                OrganizationID = testOrganization4.ID,
                City = "Redmond",
                StateAbbreviation = "WA",
                Latitude = 47.751076,
                Longitude = -120.740135,
                Phone = "(123) 456-7890",
                ContactEmail = "name@example.com",
                OperatingHours = "Monday - Friday: 9:00 AM to 5:00 PM",
                IsDefault = true
            };

            var merchants = new List<Merchant>
            {
                testOrganization1Merchant1,
                testOrganization1Merchant2,
                testOrganization2Merchant1,
                testOrganization2Merchant2,
                testOrganization3Merchant1,
                testOrganization4Merchant1,
            };
            context.Merchants.AddRange(merchants);
            #endregion
            
            context.SaveChanges();

            #region Merchant Images
            var merchantImages = new List<MerchantImage>
            {
                new MerchantImage
                {
                    IsDefault = true,
                    MerchantID = testOrganization1Merchant1.ID,
                    ImageUrl = "https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/work1.jpg"
                },
                new MerchantImage
                {
                    IsDefault = true,
                    MerchantID = testOrganization1Merchant2.ID,
                    ImageUrl = "https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/work1.jpg"
                },
                new MerchantImage
                {
                    IsDefault = true,
                    MerchantID = testOrganization2Merchant1.ID,
                    ImageUrl = "https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/work2.jpg"
                },
                new MerchantImage
                {
                    IsDefault = true,
                    MerchantID = testOrganization2Merchant2.ID,
                    ImageUrl = "https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/work2.jpg"
                },
                new MerchantImage
                {
                    IsDefault = true,
                    MerchantID = testOrganization3Merchant1.ID,
                    ImageUrl = "https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/work3.jpg"
                },
                new MerchantImage
                {
                    IsDefault = true,
                    MerchantID = testOrganization4Merchant1.ID,
                    ImageUrl = "https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/images/work4.jpg"
                }
            };
            context.MerchantImages.AddRange(merchantImages);
            #endregion

            context.SaveChanges();
        }
    }
}
