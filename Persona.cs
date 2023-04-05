class Persona{ 

    public Persona(int dni, string apellido, string nombre,DateTime fechaNacimiento, string mail){
        this.dni = dni;
        this.apellido = apellido;
        this.nombre = nombre;
        this.fechaNacimiento = fechaNacimiento;
        this.mail = mail;
    }

    public int dni {get; private set;}
    public string apellido {get; private set;}
    public string nombre {get; private set;}
    public DateTime fechaNacimiento {get; private set;}
    public string mail {get; set;}
    
    public int obtenerEdad(){
        int edad = 0;  
        edad = DateTime.Now.Year - fechaNacimiento.Year;  
        if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear){
            edad = edad - 1;  
        }

        return edad;
    }

    public bool puedeVotar(int edad){
        if (edad >= 16)
        {
            return true;
        } else return false;

    }

}