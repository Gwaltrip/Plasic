# Plasic - The Basic Style Programming Language for PLP ASM

##Keywords

|Keyword|Description|
|-------|-----------------------------------|
|global|Creates a global varrible|
|local|Creates a local varrible|
|sub|Creates a sub program start point|
|for|Creates a for loop start|
|to|Tells the for loop the limit of the loop|
|if|Creates a if start|
|is|Equality test|
|then|Finish of logic statement inside if|
|end if|Finish of if statment|
|next|Incerments a varrible and the end of a for loop|
|clear|Deletes a varrible and opens up a register|
|j|Jumps to the sub program|

##Example code

Below is sample code of a simple program.

```vbnet
global $count = 5				#globals are created on compile time
global $returns

sub main						#the default start of the program
	local $k = 30				#locals are only valid within the scope of the sub
	local $i
	local $n = 15
	
	for $i = 0 to $k			#assigns $i to 0 and only breaks if $k is $i
		if $i is $n then		#if statement which uses 'is' for comparision
			j extra				#sub program jump
		end if					#end of the if statement
	next $i						#end of for loop, also incerments $i
	
	$count = $returns + $i		#takes the returns and adds it to i then puts it into count
	clear $returns				#deletes the reference to returns
end main							#ends the main sub program

sub extra						#starts of new sub
	$returns = 0				#inits returns to 0
	local $k = 15				#varribles can be same name within the same scope.
	local $i
	
	for $i = 0 to $k
		$returns = $returns + $i
	next $i
end extra
```

##How it works

The default program enter point is the sub program "main". 

All globals entered outside of a subprogram must be placed at the top of the program file. After all of these are entered the program will enter the main.

All statements must be within a single line. 

For loops must end with a 'next' with a varrible which iterates. If statements must end with an 'end if'.  

When switching to another method you must place the name of the sub with no other words around it. In so if a sub is named 'extra', to jump to extra you must have only 'extra' written.

##Planed features

##Current limits
