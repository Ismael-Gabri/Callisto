using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Enums
{
    public enum ERole
    {
        Admin = 0,        // Acesso total à plataforma, incluindo gerenciamento de usuários e configurações
        Manager = 1,      // Responsável por supervisionar equipes e chamados
        Developer = 2,    // Atua na resolução de chamados técnicos e desenvolvimento de soluções
        ITSupport = 3,    // Suporte técnico para problemas de hardware/software
        QA = 4,           // Responsável por validar soluções e garantir qualidade
        Client = 5        // Usuário que abre e acompanha chamados (externo ou interno)
    }
}
