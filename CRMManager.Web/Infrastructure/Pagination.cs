using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMManager.Web.Infrastructure
{
    public class Pagination
    {
        public bool NextExists { get; set; }
        public bool PreviousExists { get; set; }
        public int NextNumber { get; set; }
        public int PreviousNumber { get; set; }
        public int Current { get; set; }

        public Pagination(int totalItemsCount, int countOnPage, int current)
        {
            Current = current == 0 ? current + 1 : current;
            decimal totalPages = Math.Ceiling((decimal)totalItemsCount / countOnPage);


            if (totalPages <= 1)
            {
                NextExists = false;
                PreviousExists = false;
            }
            else
            {
                if (Current == 1)
                {
                    PreviousExists = false;
                    NextExists = true;
                    NextNumber = Current + 1;
                }
                else if (current == totalPages)
                {
                    PreviousExists = true;
                    NextExists = false;
                    PreviousNumber = Current - 1;
                }
                else
                {
                    PreviousExists = true;
                    NextExists = true;
                    PreviousNumber = Current - 1;
                    NextNumber = Current + 1;
                }
            }
        }
    }
}
