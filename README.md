# Plasic - The Programming Language for PLP

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

##Example code

Below is sample code of a simple program.

```vbnet
global $count = 0				#globals are created on compile time
global $returns

sub main						#the default start of the program
	local $k = 30				#locals are only valid within the scope of the sub
	local $i
	local $n = 15
	
	for $i = 0 to $k			#assigns $i to 0 and only breaks if $k is $i
		if $i is $n then		#if statement which uses 'is' for comparision
			extra				#sub program jump
		end if					#end of the if statement
	next $i						#end of for loop, also incerments $i
	
	$count = $returns + $i		#takes the returns and adds it to i then puts it into count
	clear $returns				#deletes the reference to returns
end sub							#ends the main sub program

sub extra						#starts of new sub
	$returns = 0				#inits returns to 0
	local $k = 15				#varribles can be same name within the same scope.
	local $i
	
	for $i = 0 to $k
		$returns = $returns + $i
	next $i
end sub
```
