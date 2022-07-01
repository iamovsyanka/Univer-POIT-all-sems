.586p
.model flat, stdcall
includelib user32.lib
includelib kernel32.lib
ExitProcess proto : dword
MessageBoxA proto : dword, : dword, : dword, : dword
.stack 4096
.const

.data
mb_ok	equ 0
header	db "Костюкова Анна Олеговна, 1-ый крус, 4-ая группа", 0
ansY	db "В массиве содержится нулевой элемент", 0
ansN	db "В массиве не содержится нулевой элемент", 0
hw		dd ?
myWords		dword 1, 2, 3, 4, 5, 6, 7
.code
main proc
mov esi, OFFSET myWords
mov ax, [esi +0]
mov bx, [esi +2]
mov esi, 0
mov ebx, 1
mov eax, 0
mov ecx, 7
IN_MAS:
add eax, myWords[esi]
add esi, 4
cmp myWords[esi - 4], 0
je TRUE
loop IN_MAS
jmp END_OF_MAS
TRUE :
mov ebx, 0
loop IN_MAS
END_OF_MAS :
cmp ebx, 0
je ZERO_IN_MAS
jne NO_ZERO_IN_MAS
ZERO_IN_MAS :
invoke MessageBoxA, hw, offset ansY, offset header, mb_ok
jmp END_CMP
NO_ZERO_IN_MAS :
invoke MessageBoxA, hw, offset ansN, offset header, mb_ok
END_CMP :
push 0
call ExitProcess
main endp
end main