using System;
using System.Collections.Generic;
using System.Linq;
using TestingUnit.Services;

namespace TestingUnit.Models
{
    public class AplicationJob
    {
        private readonly int minAge = 18;
        private readonly List<string> Bilikler= new List<string>(){"C#","MVC","APi", "Sql" };
        private readonly IIdentityValidator identity;

        public AplicationJob(IIdentityValidator identity)
        {
            this.identity = identity;
        }

        public JobResult Evalute(Job job)
        {

            identity.yasheddi = job.User.Age > 50 ? Yasheddi.kecersizdir : Yasheddi.islemekolar;
            if (job.User.Age < minAge)
            {
                return JobResult.YasheddiUygundeyil;
            }

            var Discount = DiscountCv(job.BilikSayi);
            if (Discount <25) return JobResult.Biliksayiduzgundeyil;
            var IsValidNumber = identity.IsValid(job.IdentiyNumber);
            if (!IsValidNumber)
            {
                return JobResult.HrlaElaq;
            }
            var returnCv=identity.IsReturnCv();
            if (!returnCv)
            {
                return JobResult.cvGonderilmedi;
            }
            if (identity.Country.Countr!="Azerbaycan")
            {
                return JobResult.HrlaElaq;
            }
            
            

            return JobResult.BiliksayiUygundur;


        }
        private int DiscountCv(List<string>CvBilik)
        {
            var discount =
                    CvBilik.Where(i => Bilikler.Contains(i, StringComparer.OrdinalIgnoreCase)).Count();
            return (int)(double)discount / Bilikler.Count*100;


        }
        
    }
    public enum JobResult
    { 
        cvGonderilmedi,
    YasheddiUygundeyil,
    Biliksayiduzgundeyil,
    HrlaElaq,
    BiliksayiUygundur,

    
    }
}
