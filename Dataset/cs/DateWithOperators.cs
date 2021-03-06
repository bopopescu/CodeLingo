
//  DateWithOperators.cs (c) 2003 Kari Laitinen

//  The Date class in this file works in the same way as 
//  class Date in Date.cs. In this version of the class
//  operators < and > are overloaded. These operators 
//  replace the methods is_earlier_than() and is_later_than()
//  of the "real" class Date.

//  04.09.2003  C# file created.
//  04.09.2003  Last modification.

using  System ;

class  Date
{
   protected int this_day    =  1 ;
   protected int this_month  =  1 ;
   protected int this_year   =  1970 ;

   protected char  date_print_format  =  'E' ;

   public Date() {}

   public Date( int  given_day,
                int  given_month,
                int  given_year,
                char given_print_format )
   {
      this_day           =  given_day ;
      this_month         =  given_month ;
      this_year          =  given_year ;
      date_print_format  =  given_print_format ;
   }

   public Date( int  given_day,
                int  given_month,
                int  given_year )
   {
      this_day           =  given_day ;
      this_month         =  given_month ;
      this_year          =  given_year ;
   }

   public Date( string  date_as_string )
   {
      //  This constructor accepts date strings in two formats:
      //
      //    MM/DD/YYYY  is the American format.
      //    DD.MM.YYYY  is the format used in Europe.
      //
      //  Member variable date_print_format will be set either
      //  to value 'A' or 'E'. This value will be used to select
      //  correct print format when this date object is printed.

      if ( date_as_string[ 2 ]  ==  '/' )
      {
         date_print_format  =  'A' ;  // American format
         this_day   = Convert.ToInt32( date_as_string.Substring( 3, 2 ) ) ;
         this_month = Convert.ToInt32( date_as_string.Substring( 0, 2 ) ) ;
      }
      else
      {
         date_print_format  =  'E' ;  //  European format
         this_day   = Convert.ToInt32( date_as_string.Substring( 0, 2 ) ) ;
         this_month = Convert.ToInt32( date_as_string.Substring( 3, 2 ) ) ;
      }

      this_year  = Convert.ToInt32( date_as_string.Substring( 6, 4 ) ) ;
   }

   public int   day()    {  return  this_day   ; }
   public int   month()  {  return  this_month ; }
   public int   year()   {  return  this_year  ; }
   public char  get_date_print_format()  { return date_print_format ; }

   public bool is_last_day_of_month()
   {
      bool  it_is_last_day_of_month  =  false ;

      if  (  this_day  >  27  )
      {
         if  (  this_day  ==  31 )
         {
            it_is_last_day_of_month  =  true ;
         }
         else if  ( ( this_day  ==  30 ) &&
                    ( this_month  ==  2  ||  this_month  ==  4  ||
                      this_month  ==  6  ||  this_month  ==  9  ||
                      this_month  ==  11 ) )
         {
            it_is_last_day_of_month  =  true ;
         }
         else if  ( this_day  ==  29  &&  this_month  ==  2 )
         {
            it_is_last_day_of_month  =  true ;
         }
         else if  ( this_day    ==  28  &&
                    this_month  ==   2  &&
                    ! this_is_a_leap_year() )
         {
            it_is_last_day_of_month  =  true ;
         }
      }

      return  it_is_last_day_of_month ;
   }

   public bool this_is_a_leap_year()
   {
      bool  return_code  =  false ;

      if  ( this_year  %  4   ==  0 )
      {
         //  Years which are equally divisible by 4 and which
         //  are not full centuries are leap years. Centuries
         //  equally divisible by 4 are, however, leap years.

         if  ( this_year  %  100  ==  0 )
         {
            int  century  =  this_year  /  100  ;

            if  ( century  %  4   ==   0 )
            { 
               return_code  =  true ;
            }
         }
         else
         {
            return_code  =  true ;
         }
      }

      return  return_code ;
   }

   public bool is_within_dates( Date earlier_date,
                                   Date later_date   ) 
   {
      return (( equals( earlier_date )  )  ||
              ( equals(  later_date )   )  ||
              ( ( this > earlier_date ) &&
                ( this < later_date   ) )  ) ;
   }

   public int index_for_day_of_week() 
   {
      //  day_index will get a value in the range from 0 to 6,
      //  0 meaning Monday and 6 meaning Sunday.

      int  day_index  =  0 ;
      Date  known_date  =  new  Date( 6, 10, 1997 ) ;
      // Oct. 6, 1997 is Monday.

      if  ( known_date > this  )
      {
         while ( known_date.is_not_equal_to( this ) )
         {
            if ( day_index  >  0 )
            {
               day_index  --  ;
            }
            else
            {
               day_index  =  6 ;
            }

            known_date.decrement() ;
         }
      }
      else
      {
         while ( known_date.is_not_equal_to( this ) )
         {
            if ( day_index  <  6  )
            {
               day_index  ++  ;
            }
            else
            {
               day_index  =  0 ;
            }

            known_date.increment() ;
         }
      }

      return  day_index ;
   }

   public string  get_day_of_week()
   {
      String[]  days_of_week  =  { "Monday", "Tuesday", "Wednesday",
                       "Thursday", "Friday", "Saturday", "Sunday" } ;

      return  days_of_week[ index_for_day_of_week() ] ;
   }

   public void increment()
   {
      if  (  is_last_day_of_month() )
      {
         this_day   =  1 ;

         if  (  this_month  <  12  )
         {
            this_month  ++  ;
         }
         else
         {
            this_month  =  1  ;
            this_year  ++ ;
         }
      }
      else
      {
         this_day  ++  ;
      }
   }

   public void decrement()
   {
      if ( this_day  >  1  )
      {
         this_day  --  ;
      }
      else
      {
         if ( this_month  ==   5  ||  this_month  ==   7  ||
              this_month  ==  10  ||  this_month  ==  12  )
         {
            this_day    =  30 ;
            this_month  -- ;
         }
         else if ( this_month  ==   2  ||  this_month  ==   4  ||
                   this_month  ==   6  ||  this_month  ==   8  ||
                   this_month  ==   9  ||  this_month  ==  11  )
         {
            this_day    =  31 ;
            this_month  -- ;
         }
         else if (  this_month  ==  1  )
         {
            this_day    =  31  ;
            this_month  =  12  ;
            this_year   -- ;
         }
         else if (  this_month  ==  3  )
         {
            this_month  =  2  ;

            if ( this_is_a_leap_year() )
            {
               this_day  =  29  ;
            }
            else
            {
               this_day  =  28  ;
            }
         }
      }
   }

   public void get_distance_to( Date     another_date,
                                out int  years_of_distance,
                                out int  months_of_distance,
                                out int  days_of_distance )
   {
      Date  start_date ;
      Date  end_date ;
      int   start_day, end_day ;

      if ( this < another_date  )
      {
         start_date  =  this ;
         end_date    =  another_date ;  
      }
      else
      {
         start_date  =  another_date ;
         end_date    =  this ;
      }

      //  We will suppose that day 30 is the last day of every
      //  month. This way we minimize calculation errors.

      if ( start_date.is_last_day_of_month() ||
           ( start_date.day()    ==  28  &&
             start_date.month()  ==  2  )    )
      {
         start_day   =  30  ;
      }
      else
      {
         start_day   =  start_date.day() ;
      }

      if ( end_date.is_last_day_of_month() ||
           ( end_date.day()    ==  28  &&
             end_date.month()  ==  2  )    )
      {
         end_day   =  30  ;
      }
      else
      {
         end_day   =  end_date.day() ;
      }

      years_of_distance  =  end_date.year()  - start_date.year() ;
      months_of_distance =  end_date.month() - start_date.month() ;
      days_of_distance   =  end_day  -  start_day ;

      if ( days_of_distance  <  0 )
      {
         months_of_distance  --  ;
         days_of_distance  =  days_of_distance  +  30 ;
      }

      if ( months_of_distance  <  0 )
      {
         years_of_distance   --  ;
         months_of_distance  =  months_of_distance  +  12 ;
      }
   }

   public int get_week_number()
   {
      // January 1, 1883 was a Monday with week number 1.
      // January 1, 1990 was a Monday with week number 1.

      Date  date_to_increment  =  new  Date( 1, 1, 1883 ) ;
      int    week_number  =  1 ;
      int    local_index_for_day_of_week  =  0 ; // 0 means Monday

      while ( date_to_increment < this )
      {
         date_to_increment.increment() ;
 
         if ( local_index_for_day_of_week  ==  6  ) // 6 means Sunday
         {
            local_index_for_day_of_week  =  0 ; // back to Monday

            if  ( week_number  <   52 )
            {
               week_number  ++  ;
            }
            else  if  ( week_number  ==  52 )
            {
               if ( date_to_increment.day()    <=  28  &&
                    date_to_increment.month()  ==  12  )
               {
                  week_number  =  53 ;
               }
               else
               {
                  week_number  =  1  ;
               }
            }
            else  // must be week_number  53 
            {
               week_number  =  1 ;
            }
         }
         else
         {
            local_index_for_day_of_week  ++  ;
         }
      }

      return  week_number  ;
   }


   public bool equals( Date another_date )
   {
      return ( this_day    ==  another_date.day()    &&
               this_month  ==  another_date.month()  &&
               this_year   ==  another_date.year()  ) ;
   }

   public bool is_not_equal_to( Date another_date )
   {
      return ( this_day    !=  another_date.day()    ||
               this_month  !=  another_date.month()  ||
               this_year   !=  another_date.year()  ) ;
   }

   public static bool operator<( Date left_side_date,
                                 Date right_side_date )
   {
      return ((   left_side_date.year()  <   right_side_date.year()     )  ||
              ( ( left_side_date.year()  ==  right_side_date.year() )  &&
                ( left_side_date.month() <   right_side_date.month() )  )  ||
              ( ( left_side_date.year()  ==  right_side_date.year() )  &&
                ( left_side_date.month() ==  right_side_date.month() ) &&
                ( left_side_date.day()   <   right_side_date.day() )   )   ) ;
   }

   public static bool operator>( Date left_side_date,
                                 Date right_side_date )
   {
      return ((   left_side_date.year()  >   right_side_date.year()     )  ||
              ( ( left_side_date.year()  ==  right_side_date.year() )  &&
                ( left_side_date.month() >   right_side_date.month() )  )  ||
              ( ( left_side_date.year()  ==  right_side_date.year() )  &&
                ( left_side_date.month() ==  right_side_date.month() ) &&
                ( left_side_date.day()   >   right_side_date.day() )   )   ) ;
   }

   public override string ToString()
   {
      String day_as_string    =  this_day.ToString( "D2" ) ;

      String month_as_string  =  this_month.ToString( "D2" ) ;

      String year_as_string   =  this_year.ToString() ;

      string  string_to_return ;

      if ( date_print_format  ==  'A' )
      {
         string_to_return  =  month_as_string + "/" + day_as_string
                              + "/"  +  year_as_string  ;
      }
      else
      {
         string_to_return  =  day_as_string + "." + month_as_string
                           + "."  +  year_as_string  ;
      }

      return  string_to_return ;
   }
}








