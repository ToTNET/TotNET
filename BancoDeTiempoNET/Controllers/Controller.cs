using BancoDeTiempoNET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BancoDeTiempoNET.Controllers
{
    class Controller
    {
        public static float horasIniciales = 10;
        public static float balanceHoras;

        public static void Serializacion()
        {
            using (var db = new BancoDeTiempoEntitiesNET())
            {
                string path = Directory.GetCurrentDirectory();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;

                if (db.Servicio.Count() > 0)
                {
                    var serv = db.Servicio.ToList();
                    using (XmlWriter writer = XmlWriter.Create(path + "/Servicio.xml", settings))
                    {
                        XmlSerializer serializer = new XmlSerializer(serv.GetType());
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        serializer.Serialize(writer, serv, namespaces);
                        writer.Close();
                    }
                }

                if (db.Usuario.Count() > 0)
                {
                    var usu = db.Usuario.ToList();
                    using (XmlWriter writer = XmlWriter.Create(path + "/Usuario.xml", settings))
                    {
                        XmlSerializer serializer = new XmlSerializer(usu.GetType());
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        serializer.Serialize(writer, usu, namespaces);
                        writer.Close();
                    }
                }

                if (db.Notificacion.Count() > 0)
                {
                    var not = db.Notificacion.ToList();
                    using (XmlWriter writer = XmlWriter.Create(path + "/Notificacion.xml", settings))
                    {
                        XmlSerializer serializer = new XmlSerializer(not.GetType());
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        serializer.Serialize(writer, not, namespaces);
                        writer.Close();
                    }
                }

            }
        }


        public static void Deserializacion()
        {
            using (var db = new BancoDeTiempoEntitiesNET())
            {
                try
                {
                    String path = Directory.GetCurrentDirectory() + "/Usuario.xml";
                    XmlSerializer serializer = new XmlSerializer(typeof(Usuario[]));
                    StreamReader reader = new StreamReader(path);
                    Usuario[] usuarios = (Usuario[])serializer.Deserialize(reader);
                    foreach (Usuario usu in usuarios)
                    {
                        Usuario usuDelete = null;
                        usuDelete = db.Usuario.Find(usu.email);
                        if (usuDelete == null)
                        {
                            db.Usuario.Add(usu);
                            db.SaveChanges();
                        }

                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    //System.Windows.Forms.MessageBox.Show("Archivo Usuario.xml no encontrado");
                }

                try
                {
                    String path = Directory.GetCurrentDirectory() + "/Servicio.xml";
                    XmlSerializer serializer = new XmlSerializer(typeof(Servicio[]));
                    StreamReader reader = new StreamReader(path);
                    Servicio[] servicios = (Servicio[])serializer.Deserialize(reader);
                    foreach (Servicio serv in servicios)
                    {
                        if (contarServicio(serv) == 0)
                        {
                            db.Servicio.Add(serv);
                            db.SaveChanges();
                        }
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    //System.Windows.Forms.MessageBox.Show("Archivo Servicio.xml no encontrado");
                }

                try
                {
                    String path = Directory.GetCurrentDirectory() + "/Notificacion.xml";
                    XmlSerializer serializer = new XmlSerializer(typeof(Notificacion[]));
                    StreamReader reader = new StreamReader(path);
                    Notificacion[] notificaciones = (Notificacion[])serializer.Deserialize(reader);
                    foreach (Notificacion not in notificaciones)
                    {
                        Notificacion notDelete = null;
                        notDelete = db.Notificacion.Find(not.id);
                        if (notDelete == null)
                        {
                            db.Notificacion.Add(not);
                            db.SaveChanges();
                        }
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    //System.Windows.Forms.MessageBox.Show("Archivo Notificacion.xml no encontrado");
                }
            }
        }


        //listar todos
        public static List<Usuario> listaUsuarios()
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                var lst = from d in db.Usuario select d;
                return lst.ToList();
            }
        }

        public static List<Servicio> listaServicios()
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                var lst = from d in db.Servicio select d;
                return lst.ToList();
            }
        }


        public static List<Notificacion> listaNotificaciones()
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                var lst = from d in db.Notificacion select d;
                return lst.ToList();
            }
        }

        //agregar

        public static void agregarUsuario(Usuario u)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                db.Usuario.Add(u);
                db.SaveChanges();
            }
            
            
        }
        
        
        public static void agregarServicio(Servicio s)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                db.Servicio.Add(s);
                db.SaveChanges();
            }
        }
        

        public static void agregarNotificacion(Notificacion n)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                db.Notificacion.Add(n);
                db.SaveChanges();
            }
        }


        //buscar
        public static Usuario buscarUsuario(Usuario u)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return (Usuario)db.Usuario.Where(x => x.email == u.email).Single<Usuario>();
            }
        }

        public static Usuario buscarUsuarioEmail(String email)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return (Usuario)db.Usuario.Where(x => x.email == email).Single<Usuario>();
            }
        }

        public static Servicio buscarServicio(Servicio s)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return (Servicio)db.Servicio.Where(x => x.id == s.id).Single<Servicio>();
            }
        }


        public static Notificacion buscarNotificacion(Notificacion n)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return (Notificacion)db.Notificacion.Where(x => x.id == n.id).Single<Notificacion>();
            }
        }


        //modificar
        public static void modificarUsuario(Usuario u)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                db.Entry(u).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void modificarServicio(Servicio s)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                db.Entry(s).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void modificarNotificacion(Notificacion n)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                db.Entry(n).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //eliminar
        public static void eliminarUsuario(Usuario u)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                if (buscarServicioPorEmail(u.email, 0) == 0) //si no existen servicios en espera de ser realizados
                {
                    EliminarServiciosPorEmail(u.email);
                    Usuario usuario = db.Usuario.Find(u.email);
                    db.Entry(usuario).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                else System.Windows.Forms.MessageBox.Show("Error al borrar el usuario\nAsegurese de finalizar los servicios antes de eliminar el usuario.");

            }
        }

        public static void eliminarServicio(Servicio s)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                var servicio = db.Servicio.Find(s.id);
                db.Entry(servicio).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public static void eliminarNotificacion(Notificacion n)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                var notificacion = db.Notificacion.Find(n.id);
                db.Entry(notificacion).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        //contar servicio
        public static int contarServicio(Servicio s)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return db.Servicio.Where(x =>
                 x.emailDemandante == s.emailDemandante
                && x.emailOfertante == s.emailOfertante
                && x.fechaPublicacion == s.fechaPublicacion
                && x.fechaRealizacion == s.fechaRealizacion
                && x.horas == s.horas
                && x.nombre == s.nombre
                && x.servicioRealizado == s.servicioRealizado
                ).Count();
            }
        }

        public static int buscarUsuarioPorEmail(String email)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return db.Usuario.Where(x => x.email == email).Count();
            }
        }

        public static int buscarServicioPorEmail(String email, int realizado)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return db.Servicio.Where(x => (x.emailOfertante == email || x.emailDemandante == email) && x.servicioRealizado == realizado).Count();
            }
        }


        public static void EliminarServiciosPorEmail(String email)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                while (buscarServicioPorEmail(email, 1) > 0)
                {
                    Servicio servicio = db.Servicio.Where(x => (x.emailOfertante == email || x.emailDemandante == email )&& x.servicioRealizado == 1).First<Servicio>();
                    eliminarServicio(servicio);
                }

            }
        }


        public static Boolean LoginUsuario(String email, String password)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                if(db.Login.Where(x => x.email == email && x.password == password).Count() > 0 ) return true;
                return false;
            }
        }

        public static void agregarUsuarioLogin(String email, String password, String nombre, String apellido1, String apellido2, String telefono)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                 int count = db.Login.Where(x => x.email == email).Count();

                if ( count > 0)
                {
                    System.Windows.Forms.MessageBox.Show("El email ya existe en nuestra base de datos");
                }
                else
                {
                    Login login = new Login();
                    login.email = email;
                    login.password = password;
                    db.Login.Add(login);
                    db.SaveChanges();

                    Usuario usuario = new Usuario();
                    usuario.email = email;
                    usuario.nombre = nombre;
                    usuario.primerApellido = apellido1;
                    usuario.segundoApellido = apellido2;
                    usuario.telefono = telefono;
                    usuario.balanceHoras = horasIniciales;
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                }
            }
        }

        public static List<Servicio> listaServiciosDeUsuario(String email)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return db.Servicio.Where(x => x.emailDemandante == email).ToList();
            }
        }

        public static List<Servicio> listaServiciosDeUsuarioOfrecidos(String email)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return db.Servicio.Where(x => x.emailOfertante == email).ToList();
            }
        }
        public static List<Notificacion> listaNotificacionesDeUsuario(String email)
        {
            using (BancoDeTiempoEntitiesNET db = new BancoDeTiempoEntitiesNET())
            {
                return db.Notificacion.Where(x => x.emailOfertante == email || x.emailDemandante == email).ToList();
            }
        }


    }
}
