using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PointCollector.Domain.Common.Globals;

namespace PointCollector.Application.Account.Models
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public AccountStatus Status { get; set; }
    }
}
