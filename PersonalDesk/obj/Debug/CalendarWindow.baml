   M S B A M L   `   `   `  ����  PersonalDesk!    PersonalDesk.CalendarWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  Window��5       � Title$ CalendarWindow��5      $	��640��5      $	��480��6    � Topmost .  � WindowStartupLocation$ CenterScreen=�6*    � AllowsTransparency .  � WindowStyle$
 None=�6i    � ShowInTaskbar .  ��6|   Z� .��5	      � -   5         �Name$ 
LayoutRoot��5	      .+�5
   
   �� -   5        $��
Rectangle1��5
   Q   $	��199��6   $
��Left=�6!   $��310,105,0,0q�6<   $	��Top=�6c   $	��201��6{   ���	#FFD7FF7C �� RadiusY$ 14��6�   	 �� RadiusX$	 14��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      &   System.Windows.Controls.Calendar  5   
   -   5        $��	Calendar1��5   t   $��286,125,0,0q�6   $
��Left=�6(   $	��247��6C   $	��209��6O   $	��Top=�6\   ��5      �� 5       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6+   .��5      �  � Color$ 	#FFFFD200��6    � Offset$ 0.117Q�6&   � 5      $ 	#FFECF0F4��6   $ 0.209Q�6&   � 5      $ 	#FFFCFCFD��6   $ 0.209Q�6&   � 5      $ White��6   $ 1Q�6"   5      5      �� 5   
   -   5        $��Label1��5   D   $��CALENDAR��6   $��24��6#   $��378,105,0,0q�6/   $	��Top=�6R   $
��Bold"�6j   $��Normal$�6|   $
��Left=�6�   $��85��6�   5      5      