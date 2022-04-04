using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujadorParedScript : MonoBehaviour
{
	/*GBW*/

	public float _fDistancia = 5f;          //Indica la cantidad de espacio que el rect�ngulo avanza o retrocede
	public float _fVelocidadEmpuje = 3f;    //Indica la velocidad en la que el rect�ngulo se mueve
	private bool _blAdelante = true;        //Indica si el rect�ngulo avanz� o retrocedi�
	private Vector3 _vPosInicio;            //Indica la posici�n inicial del rect�ngulo

	void Awake()
	{
		_vPosInicio = transform.position;	//Se obtiene la posici�n inicial del rect�ngulo
	}

	void Update()
	{
		if (_blAdelante)
		{
			if (transform.position.x < _vPosInicio.x + _fDistancia)		//Si la posici�n del rect�ngulo es menor a la del inicio lo avanza
			{
				transform.position += Vector3.right * Time.deltaTime * _fVelocidadEmpuje;
			}
			else
				_blAdelante = false;                                    //Si no se cumple la condici�n anterior el rect�ngulo retrocedi�
		}
		else
		{
			if (transform.position.x > _vPosInicio.x)                   //Si la posici�n del rect�ngulo es mayor a la del inicio lo retrocede
			{
				transform.position -= Vector3.right * Time.deltaTime * _fVelocidadEmpuje;
			}
			else
				_blAdelante = true;                                     //Si no se cumple la condici�n anterior el rect�ngulo avanz�
		}
	}
}
