;
; Micros Project - start randNum 2nd try.asm
;
; Created: 2021/05/25 15:33:04
; Author : shenr
;


; Replace with your application code
.include "m328pdef.inc"
//.def seed1 = r16
//.def seed2 = r17
.def lowDigitScore = r17
.def timeElapsed = r16
.def temp = r18
.def setTimer = r20
.def temp2 = r21
.def sum = r8
.def phase = r22
.def temp3 = r23
.def overflows = r24
//.def answer = r25
.def score = r25
.def seed12 = r9
.def seed23 = r10

//Modulo stuff
.def rX = r6
.def rY = r7
.def rA = r1
.def rB = r2
.def MOD = r3
.def counter = r19
.def XCOPY = r4
.def YCOPY = r5

.cseg
.org 0x0000
rjmp start

.org INT0addr
jmp button

.org OC1Aaddr
jmp timer

.org 0x0018
rjmp display_score

.org 0x0020
rjmp overflow_handler

start:
CLI

ldi temp, HIGH(RAMEND)
out SPH, temp
ldi temp, LOW(RAMEND)
out SPL, temp


ldi temp, (1<<OCIE1A)
sts TIMSK1, temp


ldi temp, 0xE2
sts OCR1AH, temp
ldi temp, 0x90
sts OCR1AL, temp

ldi temp, 0x9C
sts OCR1BH, temp
ldi temp, 0x40
sts OCR1BL, temp

cbi DDRD, 2 //Sets PORTD2 for input
ldi temp, (1 << PORTD2)
out PORTD, temp

ldi temp, (1 << ISC01)//|(1 << ISC00) //detect falling edge works
sts EICRA, temp
ldi temp, (1 << INT0)
out EIMSK, temp

sbi DDRD, 5
sbi DDRD, 6
sbi DDRD, 7

sbi DDRB, 4
sbi DDRB, 3
sbi DDRB, 2
sbi DDRB, 1
sbi DDRB, 0

sbi DDRC, 1
sbi DDRC, 2

ldi setTimer, 0
mov sum, setTimer
ldi phase, 1
mov overflows, setTimer//temp
ldi temp, 1

clr timeElapsed
clr score
clr sum

SEI

loop:
	inc seed12
	inc seed23
	cpi setTimer, 1
	breq startTimer
	jmp loop

startTimer:
	cli
	ldi temp, (1<<wgm12)|(1 << CS12)|(1 << CS10)
	sts TCCR1B, temp
	ldi setTimer, 0
	//newtimer
	ldi temp, (1 << CS02)|(1 << CS00)   //1024 prescale
	out TCCR0B, temp
	ldi temp, (1 << TOIE0)
	sts TIMSK0, temp
	clr temp
	out TCNT0, temp
	ldi phase, 2
	SEI
	jmp loop


timer:
	push temp2
	in temp2, SREG
	push temp2
	SEI
	inc timeElapsed
	cpi timeElapsed, 15
	breq game_over
	rcall random_number
	rjmp display_number//call display_number

	
	pop temp2
	out SREG, temp2
	pop temp2
	reti

game_over:
	clr temp
	sts TIMSK1, temp
	ldi phase, 3
	ldi setTimer, 0
	ldi temp, (1<<OCIE1B)
	sts TIMSK1, temp
	rjmp OFF

display_score:
	push temp2
	in temp2, SREG
	push temp2
	sbi PINC, 1
	mov temp, score
	
	cpi temp, 10
	brsh display_above10
	rjmp display_number

	pop temp2
	out SREG, temp2
	pop temp2
	reti


display_above10:
	subi temp, 10
	mov lowDigitScore, temp
	ldi temp, 1
	cbi PORTB, 0
	rjmp display_number
	mov temp, LowDigitScore
	sbi PORTB, 0
	rjmp display_number

random_number:
	eor seed12, seed23
	swap seed12
	add seed23, seed12
	mov temp, seed23
	ldi temp3, 10  //mod10 in range 0-9
	rcall MODULO
	add sum, temp
	ret

display_number:
	cpi r26,0
	brne OFF
	inc r26
	cpi temp, 0
	breq num0 //display_0
	cpi temp, 1
	breq num1//display_1
	cpi temp, 2
	breq num2//display_2
	cpi temp, 3
	breq num3//display_3
	cpi temp, 4
	breq num4//display_4
	cpi temp, 5
	breq num5//display_5
	cpi temp, 6
	breq num6//display_6
	cpi temp, 7
	breq num7//display_7
	cpi temp, 8
	breq num8//display_8
	cpi temp, 9
	breq num9//display_9

	num0:
	rjmp display_0//rjmp display_0

	num1:
	rjmp display_1//rjmp display_1

	num2:
	rjmp display_2//rjmp display_2

	num3:
	rjmp display_3//rjmp display_3

	num4:
	rjmp display_4//rjmp display_4

	num5:
	rjmp display_5//rjmp display_5

	num6:
	rjmp display_6//rjmp display_6

	num7:
	rjmp display_7//rjmp display_7

	num8:
	rjmp display_8//rjmp display_8

	num9:
	rjmp display_9//rjmp display_9

OFF:
	dec r26
	cbi PORTB, 4
	cbi PORTB, 3
	cbi PORTB, 2
	cbi PORTB, 1
	cbi PORTB, 0
	cbi PORTD, 7
	cbi PORTD, 6
	cbi PORTD, 5
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_0:
	sbi PORTB, 2
	sbi PORTB, 1
	sbi PORTB, 3
	sbi PORTD, 7
	sbi PORTD, 6
	sbi PORTD, 5
	cbi PORTB, 4
	cbi PORTB, 0
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_1:
	sbi PORTB, 1
	sbi PORTD, 7
	cbi PORTD, 6
	cbi PORTD, 5
	cbi PORTB, 0
	cbi PORTB, 2
	cbi PORTB, 3
	cbi PORTB, 4
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_2:
	sbi PORTB, 2
	sbi PORTB, 1
	sbi PORTB, 4
	sbi PORTD, 5
	sbi PORTD, 6
	cbi PORTD, 7
	cbi PORTB, 0
	cbi PORTB, 3
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_3:
	sbi PORTD, 6
	sbi PORTD, 7
	sbi PORTB, 1
	sbi PORTB, 2
	sbi PORTB, 4
	cbi PORTD, 5
	cbi PORTB, 0
	cbi PORTB, 3
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_4:
	sbi PORTB, 3
	sbi PORTB, 4
	sbi PORTB, 1
	sbi PORTD, 7
	cbi PORTD, 6
	cbi PORTD, 5
	cbi PORTB, 0
	cbi PORTB, 2
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_5:
	sbi PORTB, 2
	sbi PORTB, 3
	sbi PORTB, 4
	sbi PORTD, 7
	sbi PORTD, 6
	cbi PORTD, 5
	cbi PORTB, 0
	cbi PORTB, 1
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_6:
	sbi PORTB, 2
	sbi PORTB, 3
	sbi PORTB, 4
	sbi PORTD, 7
	sbi PORTD, 6
	sbi PORTD, 5
	cbi PORTB, 0
	cbi PORTB, 1
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_7:
	sbi PORTB, 2
	sbi PORTB, 1
	sbi PORTD, 7
	cbi PORTD, 6
	cbi PORTD, 5
	cbi PORTB, 0
	cbi PORTB, 3
	cbi PORTB, 4
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_8:
	sbi PORTB, 2
	sbi PORTB, 1
	sbi PORTB, 3
	sbi PORTB, 4
	sbi PORTD, 7
	sbi PORTD, 6
	sbi PORTD, 5
	cbi PORTB, 0
	pop temp2
	out SREG, temp2
	pop temp2
	reti

display_9:
	sbi PORTB, 2
	sbi PORTB, 1
	sbi PORTB, 4
	sbi PORTB, 3
	sbi PORTD, 7
	pop temp2
	out SREG, temp2
	pop temp2
	reti


MODULO:
	ldi counter, 0
	mov rX, temp//seed2//SAVERAND
	mov rY, temp3 //CONSTANTM
	mov XCOPY, rX

	loop_1:
	sub rX, rY
	inc counter
	brcs shift
	rjmp loop_1

	shift:
	dec counter
	mov rB, counter
	mov YCOPY, rY
	mul rB, YCOPY
	mov rA, r0
	clr r0
	sub XCOPY, rA
	mov MOD, XCOPY //The modulus is generated
	mov temp, MOD //Moving the final value to RAND variable
	ret

button:
	SEI
	cpi phase, 1
	breq phase_1
	cpi phase, 2
	breq phase_2
	reti

phase_1:
	ldi setTimer, 1
	reti

phase_2:
	mov temp, sum
	ldi temp3, 3    //mod3 if = 0 then is divisible
	clr sum
	rcall MODULO
	cpi temp, 0
	breq correct_led
	rjmp wrong_led
	reti

correct_led:
	inc score
	sbi PORTC, 1
	rcall blink_led
	cbi PORTC, 1
	clr temp
	reti

wrong_led:
	dec score
	dec score
	ldi temp, 0
	cp temp, score
	brsh set_score
	continue:
	sbi PORTC, 2
	rcall blink_led
	cbi PORTC, 2
	clr temp
	reti

overflow_handler:
	inc overflows
	cpi overflows, 76  //76 overflows a second
	brne PC+2
	clr overflows
	reti

blink_led:
	clr overflows
	count_time:
		cpi overflows, 38  //half a second
		brne count_time
		ret


set_score:
	ldi score, 0
	rjmp continue