#pragma once
#include "pch.h"
#include "CFactory.h"
#include "OS13_HTCOM.h"

extern ULONG g_ServerLocks;

CFactory::CFactory() :m_Ref(1) { };
CFactory::~CFactory() { };

HRESULT STDMETHODCALLTYPE CFactory::QueryInterface(REFIID riid, void** ppv)
{
	HRESULT rc = S_OK;
	*ppv = NULL;
	if (riid == IID_IUnknown)	*ppv = (IUnknown*)this;
	else if (riid == IID_IClassFactory)	*ppv = (IClassFactory*)this;
	else rc = E_NOINTERFACE;

	if (rc == S_OK) this->AddRef();
	return rc;
};

ULONG STDMETHODCALLTYPE CFactory::AddRef(void) {
	InterlockedIncrement((LONG*)&(this->m_Ref));
	return this->m_Ref;
};

ULONG STDMETHODCALLTYPE CFactory::Release(void) {
	ULONG rc = this->m_Ref;
	if ((rc = InterlockedDecrement((LONG*)&(this->m_Ref))) == 0) delete this;

	return rc;
};

HRESULT STDMETHODCALLTYPE CFactory::CreateInstance(IUnknown* pUO, const IID& id, void** ppv) {
	HRESULT rc = E_UNEXPECTED;

	OS13* pOs13;

	if (pUO != NULL)	rc = CLASS_E_NOAGGREGATION;
	else if ((pOs13 = new OS13()) == NULL)	rc = E_OUTOFMEMORY;
	else {
		rc = pOs13->QueryInterface(id, ppv);
		pOs13->Release();
	}

	return rc;
};

HRESULT STDMETHODCALLTYPE CFactory::LockServer(BOOL b) {
	HRESULT rc = S_OK;

	if (b) InterlockedIncrement((LONG*)&(g_ServerLocks));
	else InterlockedDecrement((LONG*)&(g_ServerLocks));

	return rc;
};