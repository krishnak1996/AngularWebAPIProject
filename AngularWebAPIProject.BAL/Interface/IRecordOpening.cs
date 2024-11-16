using AngularWebAPIProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebAPIProject.BAL.Interface
{
    public interface IRecordOpening
    {
        ResponseModel GetRecordOpeningById(int id);
        ResponseModel SaveRecordOpening(RecordOpeningModel recordOpeningModel);
    }
}
