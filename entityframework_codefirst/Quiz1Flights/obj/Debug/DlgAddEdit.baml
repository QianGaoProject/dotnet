   M S B A M L   `   `   `  ����G  CQuiz1Flights, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Quiz1FlightsQuiz1Flights  5   	       Quiz1Flights.DlgAddEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Quiz1Flights     5   	   -   5          � Title$  Add/Edit Dialog��5       � SizeToContent$ WidthAndHeight=�6!    � WindowStartupLocation$ CenterScreen=�6@   .��5
      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6/   .+�5      �� $	��Id:��6   $��5q�6#   $��30��6.   $��75��6:   �� 5      -   5         ��Name$ 
lblIdValue��5      $	��...��6(   $��5q�67   $	��164��6C   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   .+�5      �� $��Date:��6   $��5q�6%   $��75��61   �� 5      -   5         ��Name$ tbDate��5      $��23��6(   $��5q�64    �� TextWrapping$
 Wrap=�6?   $	��164��6U   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   .+�5      �� $��
From code:��6   $��5q�6*   $��75��66   �� 5      -   5        $ 
tbFromCode��5      $��23��6,   $��5q�68   $
 Wrap=�6C   $	��164��6X   5       �� 5!   
   $ 
Horizontal=�6   $��3��6.   .+�5"      �� $��To code:��6   $��5q�6(   $��75��64   �� 5#      -   5        $ tbToCode��5#      $��23��6)   $��5q�65   $
 Wrap=�6@   $	��164��6V   5$      �� 5%   
   $ 
Horizontal=�6   $��4��6.   .+�5&      �� -   5         ��Name$ infoFlights��5&      $��5q�6-   	 J� RenderTransformOrigin$	 0.275,0.346&�69   $	��230��6]   5'      �� 5(   
   $ 
Horizontal=�6   $��5��6.   .+�5)      �� -   5        
 ��Name$
 
sPassenger��5)      $��20, 5, 5, 5q�6)   $
��Left=�6t   $	��Top=�6�   $	��230��6�    � Minimum$ 0Q�6�    � Maximum$	 200Q�6�    �� TickPlacement$ BottomRight=�6�    �� TickFrequency$ 10Q�6�    � SmallChange$ 1Q�6&   � LargeChange$ 0Q�66   � Value 6>   ��  �� ElementName$ tbPassenger�� �� Path$
 Text�66  5*      �� 5+   
   $ 
Horizontal=�6   $��6��6.   .+�5,      �� $��
Passenger:��6   $��5q�6+   $��75��67   �� 5-      -   5        $ tbPassenger��5-      $��5q�6+   $
��Left=�66   $��23��6Q   $
 Wrap=�6^   $	��Top=�6r   $��49��6�   5.      �� 5/   
   $ 
Horizontal=�6   $��7��6.   .+�50      �� -	   5        $��Cancel��50      $��15 15q�6>   $��75��6N   $��30��6Y   �� 51      -
   5         ��Name$ btSave��51       �� 	IsDefault . $
��Save��6K   $��15 15q�6Z   $��75��6j   $��30��6u   52      53      54      