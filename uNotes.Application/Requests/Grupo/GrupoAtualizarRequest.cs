﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Application.Requests.Grupo
{
    public class GrupoAtualizarRequest
    {
        public Guid Id  { get; set; }
        public string Nome { get; set; }
    }
}
