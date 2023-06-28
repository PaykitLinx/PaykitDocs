#include "StdAfx.h"
#include "PreviewComprovante.h"
using namespace ExemploInterfaceIntegracao;
using namespace System;

void PreviewComprovante::RealizarDialogo(String^ comprovante)
{
	rtbComprovante->Text = comprovante;
	this->ShowDialog();
}