
//  vectoring.cpp (c) 2000-2004 Kari Laitinen

#include  <iostream.h>
#include  <string>
#include  <vector>

int main()
{
   vector<int>  array_of_integers ;

   for ( int integer_to_array  =  202 ;
             integer_to_array  <  303 ;
             integer_to_array  =  integer_to_array  +  11 )
   {
      array_of_integers.push_back( integer_to_array ) ;
   }

   cout << "\n  Contents of array_of_integers: \n\n  " ;

   for ( int integer_index  =  0 ;
             integer_index  <  array_of_integers.size() ;
             integer_index  ++  )
   {
      cout << "   "  <<  array_of_integers[ integer_index ] ;
   }

   vector<string>  array_of_text_lines ;

   string  first_line   =  "   The following are Morse codes:" ;

   array_of_text_lines.push_back( first_line ) ;

   array_of_text_lines.push_back(
     string("   A .-    B -...  C -.-.  D -..   E .     F ..-." ) ) ;
   array_of_text_lines.push_back(
     string("   G --.   H ....  I ..    J .---  K -.-   L .-.." ) ) ;
   array_of_text_lines.push_back(
     string("   M --    N -.    O ---   P .--.  Q --.-  R .-. "
          "\n   S ...   T -     U ..-   V ...-  W .--   X -..-" ) ) ;
   array_of_text_lines.push_back(
     string("   Y -.--  Z --..  1 .---- 2 ..--- 3 ...-- 4 ....-"
          "\n   5 ..... 6 -.... 7 --... 8 ---.. 9 ----. 0 -----" ) );

   cout << "\n\n  Contents of array_of_text_lines: \n" ;

   vector<string>::iterator  text_line_to_print ;

   text_line_to_print  =  array_of_text_lines.begin() ;

   while ( text_line_to_print  !=  array_of_text_lines.end() )
   {
      cout  <<  "\n"  <<  *text_line_to_print ;

      text_line_to_print  ++  ;
   }

   cout << "\n" ;
}




