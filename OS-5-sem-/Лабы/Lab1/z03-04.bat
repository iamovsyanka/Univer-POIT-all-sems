@echo off
echo ~~~Parameters: %1 %2 %3
echo ~~~Parameter1: %1
echo ~~~Parameter2: %2
echo ~~~Parameter3: %3
set /a plus = %1 + %2
set /a mult = %1 * %2 
set /a del = %3 / %2 
set /a minus = %2 - %1 
set /a result = (%2 - %1) * (%1 - %2)
echo ~~~%1 + %2 = %plus%
echo ~~~%1 * %2 = %mult% 
echo ~~~%3 / %2 = %del% 
echo ~~~%2 - %1 = %minus% 
echo ~~~(%2 - %1)*(%1 - %2) = %result% 