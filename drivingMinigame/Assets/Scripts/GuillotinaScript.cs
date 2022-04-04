using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuillotinaScript : MonoBehaviour
{
	/*GBW*/

	public float _fAnguloLimite = 75f;          //Indica el ángulo máximo que la guillotina puede girar
	public bool _blOrigenDistinto = false;		//Indica si la guillotina no debe iniciar en el ángulo 0
	private float _fNumRandom = 0f;             //Número random para definir ángulo disinto al 0

	void Awake()
	{
		if (_blOrigenDistinto)
			_fNumRandom = 60f;    //Si se indica origen distinto el número random es mayor 0
	}
	void Update()
	{
		float angle = _fAnguloLimite * Mathf.Sin(Time.time*2 + _fNumRandom);      //Se establece el ángulo cada Update dependiendo si se indicó origen distinto
		transform.localRotation = Quaternion.Euler(180, 90, angle);                //Se establece la rotación de la guillotina con el ángulo calculado
	}
}
