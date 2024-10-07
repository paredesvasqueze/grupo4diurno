using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class CompraDomain
    {
        private readonly AlumnoRepository _alumnoRepository;

        public CompraDomain(AlumnoRepository alumnoRepository)
        {
           
                _alumnoRepository = alumnoRepository;     
        }

        public IEnumerable<Alumno> ObtenerAlumnoTodos()
        {
            try
            {
                return _alumnoRepository.ObtenerAlumnoTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarAlumno(Alumno oAlumno)
        {
            try
            {
                return _alumnoRepository.InsertarAlumno(oAlumno);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizararAlumno(Alumno oAlumno)
        {
            try
            {
                return _alumnoRepository.InsertarAlumno(oAlumno);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
