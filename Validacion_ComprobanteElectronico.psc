Algoritmo Validacion_ComprobanteElectronico
	Definir numero Como Cadena
    Definir valido Como Logico
    Definir i Como Entero
    Definir caracter Como Cadena
	
 
    Escribir "Ingrese el número de comprobante:"
    Leer numero
	
    valido <- Verdadero
	
    Si Longitud(numero) <> 13 Entonces
        valido <- Falso
    FinSi
	

    Si valido Entonces
        caracter <- Subcadena(numero,1,1)
		
        Si caracter <> "B" Y caracter <> "F" Entonces
            valido <- Falso
        FinSi
    FinSi
	
 
    Si valido Entonces
        Si Subcadena(numero,5,5) <> "-" Entonces
            valido <- Falso
        FinSi
    FinSi
	

    Si valido Entonces
        Para i <- 2 Hasta 4 Hacer
            caracter <- Subcadena(numero,i,i)
			
            Si caracter < "0" O caracter > "9" Entonces
                valido <- Falso
            FinSi
        FinPara
    FinSi
	
   
    Si valido Entonces
        Para i <- 6 Hasta 13 Hacer
            caracter <- Subcadena(numero,i,i)
			
            Si caracter < "0" O caracter > "9" Entonces
                valido <- Falso
            FinSi
        FinPara
    FinSi
	
   
    Si valido Entonces
  
        Escribir "Comprobante electrónico VÁLIDO."
    SiNo
    
        Escribir "Comprobante electrónico INVÁLIDO."
    FinSi
	
FinAlgoritmo

