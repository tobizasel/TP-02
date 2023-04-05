// See https://aka.ms/new-console-template for more information
using System.Linq;

// DateTime nacimiento1 = new DateTime(2006,11,3);
// Persona p1 = new Persona(4743, "Zaselsky", "Tobias", nacimiento1, "tobiaszasel@gmail.com");
List<Persona> listaPersonas = new List<Persona>();

int eleccion;

do{

 eleccion = Menu();

switch (eleccion)
{
    
    case 1:
        CargarPersona(listaPersonas);
    break;
    case 2: 
        ObtenerDatos(listaPersonas);
    break;
    case 3:
        BuscarPersona(listaPersonas);
    break;
    case 4: 
        CambiarMail(listaPersonas);
    break;    
    default:
        eleccion = 5;
    break;
}
} while(eleccion != 5);

static int Menu(){

    Console.WriteLine("I. Cargar Nueva Persona\nII. Obtener Estadísticas del Censo\nIII. Buscar Persona\nIV. Modificar Mail de una Persona.\nV. Salir\n");
    int eleccion = int.Parse(Console.ReadLine());
    return eleccion;
}

static int IngresarInt(string mensaje){
    Console.WriteLine(mensaje);
    int dato = int.Parse(Console.ReadLine());
    return dato;
}

static string IngresarString(string mensaje){
    Console.WriteLine(mensaje);
    string dato = Console.ReadLine();
    return dato;
}
static void CargarPersona(List<Persona> listaPersonas){

    int dni = IngresarInt("Ingresa el dni");
    bool validoDni = validarDni(dni, listaPersonas);
    string apellido = IngresarString("Ingresa el apellido");
    string nombre = IngresarString("Ingresa el nombre");
    string mail = IngresarString("Ingresa el mail");
    string fechaS = IngresarString("Ingresa tu fecha de nacimiento (YYYY/MM/DD)");

    bool validoFecha = validarFecha(fechaS, listaPersonas);

    if (validoDni && validoFecha)
    {
        DateTime fecha = Convert.ToDateTime(fechaS); 
        listaPersonas.Add(new Persona(dni, apellido, nombre, fecha, mail));
    }
    else
    {
        Console.WriteLine("Error de datos\n");
    }
}

static bool validarDni(int dni, List<Persona> listaPersonas){

    int contador = 0;

    for (int i = 0; i < listaPersonas.Count; i++)
    {
        if (dni == listaPersonas[i].dni)
        {
            contador++;
        }
    }

    if (contador < 1)
    {
        return true;
    }
    return false;
}

static void ObtenerDatos(List<Persona> listaPersonas){
    int contador = 0;
    int sumaEdades = 0;
    foreach (Persona item in listaPersonas)
    {
        if (item.puedeVotar(item.obtenerEdad()))
        {
            contador++;
        }
    }

    if (listaPersonas.Count == 0)
    {
        Console.WriteLine("No se ingresaron personas");

    } else {
        Console.WriteLine("Cantidad de personas " + listaPersonas.Count);
        Console.WriteLine("Cantidad de personas aptas para votar: " + contador);
        foreach (Persona item in listaPersonas)
        {
            sumaEdades += item.obtenerEdad();
        }
        Console.WriteLine("El promedio de edad es: " + sumaEdades / listaPersonas.Count);

    }

}

static void BuscarPersona(List<Persona> listaPersonas){

    int dniBuscado = IngresarInt("Cual es el dni de la persona buscada?");
    bool existe = false;

    foreach (Persona item in listaPersonas)
    {
        if (item.dni == dniBuscado)
        {
            Console.WriteLine("El nombre es: " + item.nombre + " " + item.apellido);
            Console.WriteLine("La edad es: " + item.obtenerEdad());
            Console.WriteLine("El mail es: " + item.mail);
            if (item.puedeVotar(item.obtenerEdad()))
            {
                Console.WriteLine("Puede votar");
            } else { Console.WriteLine("No puede votar");}
            existe = true;
            break;
        }
    }

    if (!existe)
    {
        Console.WriteLine("No se encuentra el dni");
    }

}

static void CambiarMail(List<Persona> listaPersonas){

    Console.WriteLine("De quien queres cambiar el mail?");
    int dniBuscado = int.Parse(Console.ReadLine());
        
    Console.WriteLine("Cual es el nuevo mail?");
    string nuevoMail = Console.ReadLine();

    bool existe = false;

    foreach (Persona item in listaPersonas)
    {
        if (item.dni == dniBuscado)
        {
            item.mail = nuevoMail;
            existe = true;
        }
    }

    if (!existe)
    {
        Console.WriteLine("No se encuentra el dni");
    }

}

static bool validarFecha(string fechaS,List<Persona> listaPersonas){

    if(fechaS.Length != 10 || !fechaS.Contains("/")){
        return false;
    }

    return true;
}
