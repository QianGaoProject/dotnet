   M S B A M L   `   `   `  ����G  CQuiz1Flights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Quiz1FlightsQuiz1Flights  5   	       Quiz1Flights.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Quiz1Flights     5   	   -   5          � Title$  Flights Manager��5       � SizeToContent$ WidthAndHeight=�5	   	    � 
ResizeMode$ NoResize=�5
   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ btAdd��5      $	��Add��68   $��75��6F   $��30��6Q   5      �� 5   
   -   5        $��	lvFlights��5   +   $��1��6   $��5q�6     �� SelectionMode$ Single=�6�   ��6<   ��  � ContextMenu 5      �� 5      .@�5      m� -   5        $��Delete��5      6/   5      	 �� View	 5      �� 5      .P�5      �� $��Id��6%   
 �� Width$	
 250��61    �� DisplayMemberBinding 6=   �� *Id+�� 5      $��On day��6%   $	
 150��65    6A   �� *OnDay+�� 5       $��	From code��6%   $	
 150��68    6D   �� *
FromCode+�� 5!      $��To code��6%   $	
 150��66    6D   �� *ToCode+�� 5"      $��Type flight��6%   $	
 150��6:    6H   �� *
TypeFlight+�� 5#      $��	Passenger��6%   $	
 150��68    6F   �� *	Passenger+5%      5'      5(      5)      