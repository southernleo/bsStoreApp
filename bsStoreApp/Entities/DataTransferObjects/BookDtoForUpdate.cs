﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
     public record BookDtoForUpdate(int id,String Title,decimal Price);
   
}
