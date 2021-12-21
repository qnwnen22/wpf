using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Hello(string name);
        //{
        //    return $"Hello {name}!";
        //}
        [OperationContract]
        bool SignIn(Member member);
        [OperationContract]
        bool SignUp(Member member);
    }
}
