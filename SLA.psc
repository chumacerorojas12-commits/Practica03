Algoritmo SLA
	
		
		Definir anioC, mesC, diaC, horaC, minutoC, anioR, mesR, diaR, horaR, minutoR , anioActual, mesActual, diaActual  Como Entero
		Definir totalHoras, horasDeMas , horaInicio, horaFin Como Real
		Definir diaSemana, diasMes Como Entero
		Definir a, e, m Como Entero
		Definir seguir, bisiesto Como Logico
		
		Escribir "=== CALCULO DE SLA DE TICKET DE SOPORTE ==="
		
		Escribir "Ingrese fecha de creacion"
		Escribir "Año:"
		Leer anioC
		Escribir "Mes:"
		Leer mesC
		Escribir "Dia:"
		Leer diaC
		Escribir "Hora formato 24 horas:"
		Leer horaC
		Escribir "Minuto:"
		Leer minutoC
		
		Escribir ""
		Escribir "Ingrese fecha de resolucion"
		Escribir "Año:"
		Leer anioR
		Escribir "Mes:"
		Leer mesR
		Escribir "Dia:"
		Leer diaR
		Escribir "Hora formato 24 horas:"
		Leer horaR
		Escribir "Minuto:"
		Leer minutoR
		
		totalHoras <- 0
		
		anioActual <- anioC
		mesActual <- mesC
		diaActual <- diaC
		
		seguir <- Verdadero
		
		Mientras seguir = Verdadero Hacer
		
			a <- trunc((14 - mesActual) / 12)
			e <- anioActual - a
			m <- mesActual + 12 * a - 2
			
			diaSemana <- (diaActual + e + trunc(e / 4) - trunc(e / 100) + trunc(e / 400) + trunc((31 * m) / 12)) MOD 7
			
		
			Si diaSemana <> 0 Y diaSemana <> 6 Entonces
				
				horaInicio <- 9
				horaFin <- 17
				
				
				Si anioActual = anioC Y mesActual = mesC Y diaActual = diaC Entonces
					
					horaInicio <- horaC + minutoC / 60
					
					Si horaInicio < 9 Entonces
						horaInicio <- 9
					FinSi
					
					Si horaInicio > 17 Entonces
						horaInicio <- 17
					FinSi
					
				FinSi
				
				
				Si anioActual = anioR Y mesActual = mesR Y diaActual = diaR Entonces
					
					horaFin <- horaR + minutoR / 60
					
					Si horaFin > 17 Entonces
						horaFin <- 17
					FinSi
					
					Si horaFin < 9 Entonces
						horaFin <- 9
					FinSi
					
				FinSi
				
				
				Si horaFin > horaInicio Entonces
					totalHoras <- totalHoras + (horaFin - horaInicio)
				FinSi
				
			FinSi
			
			
			Si anioActual = anioR Y mesActual = mesR Y diaActual = diaR Entonces
				
				seguir <- Falso
				
			SiNo
				
				
				Segun mesActual Hacer
					1:
						diasMes <- 31
					2:
						Si (anioActual MOD 4 = 0 Y anioActual MOD 100 <> 0) O (anioActual MOD 400 = 0) Entonces
							bisiesto <- Verdadero
						SiNo
							bisiesto <- Falso
						FinSi
						
						Si bisiesto = Verdadero Entonces
							diasMes <- 29
						SiNo
							diasMes <- 28
						FinSi
					3:
						diasMes <- 31
					4:
						diasMes <- 30
					5:
						diasMes <- 31
					6:
						diasMes <- 30
					7:
						diasMes <- 31
					8:
						diasMes <- 31
					9:
						diasMes <- 30
					10:
						diasMes <- 31
					11:
						diasMes <- 30
					12:
						diasMes <- 31
				FinSegun
				
				
				diaActual <- diaActual + 1
				
				Si diaActual > diasMes Entonces
					diaActual <- 1
					mesActual <- mesActual + 1
					
					Si mesActual > 12 Entonces
						mesActual <- 1
						anioActual <- anioActual + 1
					FinSi
				FinSi
				
			FinSi
			
		FinMientras
		
		Escribir ""
		Escribir "Horas laborales : ", totalHoras, " horas"
		
		Si totalHoras < 8 Entonces
			Escribir "Estado SLA: Cumplido"
			
		SiNo
			horasDeMas <- totalHoras - 8
			Escribir "Estado SLA: Incumplido: ", horasDeMas, " horas de mas"
		FinSi
		
FinAlgoritmo

