using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegocioPce
{
    public class Equipo : ObservableObject, IPersistente, IDataErrorInfo
    {
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public int EquipoId { get; set; }

        private string _nombreEquipo;
        private int _cantidadJugadores;
        private string _nombreDT;
        private string _tipoEquipo;
        private string _capitanEquipo;
        private bool _datosValidos;
        public string NombreEquipo
        { 
            get { return _nombreEquipo; }
            set
            {
                OnPropertyChanged(ref _nombreEquipo, value);
            }
        }
        public int CantidadJugadores 
        {
            get { return _cantidadJugadores; }
            set
            {
                OnPropertyChanged(ref _cantidadJugadores, value);
            }
        }
        public string NombreDT 
        {
            get { return _nombreDT; }
            set
            {
                OnPropertyChanged(ref _nombreDT, value);
            }
        }
        public string TipoEquipo 
        {
            get { return _tipoEquipo; }
            set
            {
                OnPropertyChanged(ref _tipoEquipo, value);
            }
        }
        public string CapitanEquipo 
        {

            get { return _capitanEquipo; }
            set
            {
                OnPropertyChanged(ref _capitanEquipo, value);
            }
        }
        public bool TieneSub21 { get; set; }
        public bool DatosValidos
        {
            get { return _datosValidos; }
            set
            {
                if (_datosValidos != value)
                {
                    _datosValidos = value;
                    OnPropertyChanged(nameof(DatosValidos));
                }
            }
        }

        public string Error { get { return null; } }

        public string this[string name]
        { 
            get
            {
                string res = null;
                switch(name) 
                {
                    case "NombreEquipo":
                        if (string.IsNullOrEmpty(NombreEquipo))
                            res = "Nombre Equipo obligatorio";
                        else if(NombreEquipo.Length < 8 || NombreEquipo.Length > 15)
                            res = "Nombre solo puede tener minimo 8 y maximo 15 caracteres";
                        break;

                    case "CantidadJugadores":
                        if (CantidadJugadores < 16 || CantidadJugadores > 25)
                            res = "Cantidad solo puede tener 16 a 25 jugadores";
                        break;

                    case "NombreDT":
                        if (string.IsNullOrEmpty(NombreDT))
                            res = "Nombre Equipo obligatorio";
                        else if (NombreDT.Length < 5 || NombreDT.Length > 30)
                            res = "Nombre solo puede tener minimo 5 y maximo 30 caracteres";
                        break;

                    case "TipoEquipo":
                        if (string.IsNullOrEmpty(TipoEquipo))
                            res = "Tipo de equipo es obligatorio";
                        break;

                    case "CapitanEquipo":
                        if (string.IsNullOrEmpty(CapitanEquipo))
                            res = "Nombre Equipo obligatorio";
                        else if (CapitanEquipo.Length < 5 || CapitanEquipo.Length > 30)
                            res = "Nombre solo puede tener minimo 5 y maximo 30 caracteres";
                        break;
                        
                }
                if(ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = res;
                else if(res != null)
                    ErrorCollection.Add(name, res);

                DatosValidos = ErrorCollection.All(error => string.IsNullOrEmpty(error.Value));

                OnPropertyChanged(nameof(DatosValidos));

                return res;
            }
        }


        public bool Create()
        {
            try
            {
                CommonPce.ModelEquipo.spEquipoSave(
                    AES_Helper.EncryptString(this.NombreEquipo),
                    this.CantidadJugadores,
                    AES_Helper.EncryptString(this.NombreDT),
                    AES_Helper.EncryptString(this.TipoEquipo),
                    AES_Helper.EncryptString(this.CapitanEquipo),
                    this.TieneSub21
                );

                CommonPce.ModelEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                CommonPce.ModelEquipo.spEquipoDeleteById(id);
                CommonPce.ModelEquipo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Read(int id)
        {
            try
            {
                LibraryPce.vwPCE equipo = CommonPce.ModelEquipo.vwPCE.First(l => l.EquipoId == id);

                this.EquipoId = equipo.EquipoId;
                this.NombreEquipo = AES_Helper.DecryptString(equipo.NombreEquipo);
                this.CantidadJugadores = equipo.CantidadJugadores;
                this.NombreDT = AES_Helper.DecryptString(equipo.NombreDT);
                this.TipoEquipo = AES_Helper.DecryptString(equipo.TipoEquipo);
                this.CapitanEquipo = AES_Helper.DecryptString(equipo.CapitanEquipo);
                this.TieneSub21 = equipo.TieneSub21;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                CommonPce.ModelEquipo.spEquipoUpdateById(
                    this.EquipoId,
                    AES_Helper.EncryptString(this.NombreEquipo),
                    this.CantidadJugadores,
                    AES_Helper.EncryptString(this.NombreDT),
                    AES_Helper.EncryptString(this.TipoEquipo),
                    AES_Helper.EncryptString(this.CapitanEquipo),
                    this.TieneSub21
                );

                CommonPce.ModelEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
