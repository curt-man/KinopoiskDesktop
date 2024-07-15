using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.Models
{
    public interface ISyncableEntity<T>
    {
        public DateTime? SyncedAt { get; set; }
        public TimeSpan? SyncPeriod { get; set; }
        public T SyncProperty { get; }
    }
}
