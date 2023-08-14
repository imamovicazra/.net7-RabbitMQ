using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAirline.Service.Interface
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message);
    }
}
