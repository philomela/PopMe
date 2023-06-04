using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenterService.Application.Common.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    string GetConnectionString();
}
