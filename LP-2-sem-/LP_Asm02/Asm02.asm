.586p
.model flat, stdcall
includelib kernel32.lib
ExitProcess proto : dword
MessageBoxA proto : dword, : dword, : dword, : dword
.stack 4096
.const

.data
MB_OK	equ 0
str1	byte "Результат", 0
str2	byte "Результат сложения: ", 0
HW		DD ?

.code
main proc
	mov al, 3d
	add al, 4d
	add al, 48
	mov str2[20], al
	push MB_OK
	push offset str1
	push offset str2
	push HW
	call MessageBoxA
	push 0
	call ExitProcess
	main endp
end main