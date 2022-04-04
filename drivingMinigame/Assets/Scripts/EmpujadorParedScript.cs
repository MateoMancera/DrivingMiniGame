using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujadorParedScript : MonoBehaviour
{
	/*GBW*/

	public float _fDistancia = 5f;          //Indica la cantidad de espacio que el rectángulo avanza o retrocede
	public float _fVelocidadEmpuje = 3f;    //Indica la velocidad en la que el rectángulo se mueve
	private bool _blAdelante = true;        //Indica si el rectángulo avanzó o retrocedió
	private Vector3 _vPosInicio;            //Indica la posición inicial del rectángulo

	void Awake()
	{
		_vPosInicio = transform.position;	//Se obtiene la posición inicial del rectángulo
	}

	void Update()
	{
		if (_blAdelante)
		{
			if (transform.position.x < _vPosInicio.x + _fDistancia)		//Si la posición del rectángulo es menor a la del inicio lo avanza
			{
				transform.position += Vector3.right * Time.deltaTime * _fVelocidadEmpuje;
			}
			else
				_blAdelante = false;                                    //Si no se cumple la condición anterior el rectángulo retrocedió
		}
		else
		{
			if (transform.position.x > _vPosInicio.x)                   //Si la posición del rectángulo es mayor a la del inicio lo retrocede
			{
				transform.position -= Vector3.right * Time.deltaTime * _fVelocidadEmpuje;
			}
			else
				_blAdelante = true;                                     //Si no se cumple la condición anterior el rectángulo avanzó
		}
	}
}
