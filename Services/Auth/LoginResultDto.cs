using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesQueries.Auth
{
    public class LoginResultDto
    {
        public bool Succeeded { get; set; }
        public string? errors { get; set; } //Se pone el error de la exception??
        public string? message { get; set; }


        public LoginResultDto(bool _status, string? _messagge)
        {
            Succeeded = _status;
            errors = _messagge;
        }

        public LoginResultDto()
        {

        }
    }


}
