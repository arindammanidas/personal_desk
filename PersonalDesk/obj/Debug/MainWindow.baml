   M S B A M L   `   `   `  ����  PersonalDesk    PersonalDesk.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6?   -   5          �Name$  PDesk��5       � Title$ Personal Desk��5      $	��800��5	      $	��600��6   $y�Visible=�61    � WindowStartupLocation$ CenterScreen=�6F    � WindowState$ 	Maximized=�6k    � 
ResizeMode$ NoResize=�6�    � AllowsTransparency .  � WindowStyle$
 None=�6�    � Icon$' !/PersonalDesk;component/PDesk.ico��6�   ��6   Z�  � 	Resources 5
         ButtonStyle1	 �� 
TargetType
 �� Property �� Value �� 
TargetType J� SnapsToDevicePixels � ToolTip �� Triggers P� Property P� Value  ButtonStyle2��%	  &	        &	 �    �� 5      "	 ��6   .�5      �� 
 � �� 5      �� 5      " ��6   .R�5      � .+�5   	   �� ��6   Z� �� 5   	   #��z��6   ��. # z 6x   #��z��6�   $��-��6�   $ Minimize��6�   5   	    5      P� 5   	    �@J�	IsFocused . 6&   P� 5   	    �@��IsDefaulted . 6(   P� 5   	    �@J�IsMouseOver . 6(   P� 5   	    � �� . 6&   P� 5   	    � {� .  6&   5      5      5      �� 5      "	 ��6   5      .��5!      � -   5         �Name$ 
LayoutRoot��5!       � RowDefinitions 5"      �� 5#      $��0.62* �6   �� 5$      $��0.38* �6   .+�5&      �� -   5        $��	recWindow��5&   .   
���   �$��2��6    J� Opacity 6?   ��  �� ElementName$ opacitySlider�� �� Path$ Value���5'      �� 5(       �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6+    �� 
StartPoint$ 0.5,0&�6O   .��5)      �  � Color$ 	#FFFFF500��6    � Offset$ 0.176Q�6&   � 5*      $ White��6   $ 1Q�6"   5+      5-      �� 5.      
��� ���$��80��6    $��
256,40,0,0q�6,   $	��Top=�6@   
������� J� Effect 5/      -  'System.Windows.Media.Effects.BlurEffect  50      52      �� 53      $��0,40,0,0q�6   $��80��6    $	��Top=�6,   ���	#FFFFAF00$
��Left=�6U   $	��265��6p   
������� 54        55      57      �� 58      $��34��6   $��	37,51,0,0q�6   $
��Wrap=�6-   $��Personal Desk��6A   $	��Top=�6V   $��29.333(�6n   $��Italic$�6�   $5��//PersonalDesk;component/Fonts/#SketchFlow Print)�6�   $
��Bold"�6�   
�������$
��Left=�6�   $	��228��6  �� 59      $��26��6   $��	37,85,0,0q�6   $
��Wrap=�6-   $��simplifying tasks... ��6A   $	��Top=�6^   
�������$5��//PersonalDesk;component/Fonts/#SketchFlow Print)�6�   $��16(�6�    �� TextAlignment$ Center=�6�   $
��Left=�6�   $	��228��6  �� 5:      -   5         ��Name$ button��5:      $��-��6   $��Right=�6'   $��40��6C   $��0,0,39,0q�6O     ButtonStyle3#���  6a   $	��Top=�6�   $��41��6�   $��24(�6�   $4��./PersonalDesk;component/Fonts/#Tempus Sans ITC)�6�   $
��Bold"�6�   $ Minimize��6  ��5;      �� 5<      $ 0.5,1&�6   $ 0.5,0&�6+   .��5=      � $ White��6   $ 0Q�6"   � 5>      $ 	#FFE3E5F0��6   $	 0.5Q�6&   � 5?      $ 	#FFFFAF00��6   $ 1Q�6&   5@      5B      �� 5C      -   5        $ button1��5C      $��x��6   $��Right=�6(   $��40��6D     ButtonStyle4#���  6P   $	��Top=�6w   $��39��6�   $4��./PersonalDesk;component/Fonts/#Tempus Sans ITC)�6�   $��24(�6�   $ Close��6�   �� 5D   
   ���	#FFB4FF36$��0,0,0,146.28q�6%   $��1��6;   $��59.844��6H   $��Bottom=�6X   $��Right=�6s   $��336.376��6�    �� RadiusY$ 13.173��6�     �� RadiusX$  13.173��6�   
������� 5E        5F      5H      �� 5I      $��
0,0,0,88.5q�6   $��1��6"   ���	#FFFEAE00
�������$��75.78��6O   $��Bottom=�6^    5J        5K      5M      �� 5N      -   5        $��opacitySlider��5N   �   $��Right=�6   $��22��6'   $��0,0,32.75,52.28q�63   $��1��6L   $��Bottom=�6Y   $	��152��6t   ! � Minimum$	! 0.5Q�6�   " � Maximum$" 1Q�6�   # � Value$	# 0.8Q�6�   ���	#FFFFA600$ �� AutoToolTipPlacement$
$ None=�6�   % �� TickFrequency$	% 0.1Q�6�   $ Transparency��6  �� 5O   
   -   5        $��rssBlock��5O   �   $��50��6   $��357.627,61,43.5,0q�6    $
��Wrap=�6;   $	��Top=�6O   
�������$��18(�6z   $.��(/PersonalDesk;component/Fonts/#Agency FB)�6�   $ Center=�6�   $��Normal$�6�   $-��'<<  Click the button to view RSS feeds.��6�   & � Cursor$
& Hand��6-  $ Click to view full story��6;  �� 5P      -   5        $��	timeblock��5P     $��0,0,21.75,88.28q�6   $��1��6'   $
��Wrap=�64   $��12:00 AM��6H   $:��4/PersonalDesk;component/Fonts/#Arial Rounded MT Bold)�6X   $��48(�6�   $ Center=�6�   
�������$��Right=�6�   $��238.25��6�   $��Bottom=�6�   $��67��6)   5Q        5R      5T      �� 5U      -	   5        $��notesButton��5U   �   $�� ��6   $
��Left=�6   $
��70.5��61   $��50,0,0,114.624q�6?   $��1��6W     ButtonStyle5#���  6d   $��Bottom=�6�   $
��54.5��6�   $ Notes��6�   6�   �� 5V      -
   5        $��scribbleButton��5V   �   $�� ��6   $
��Left=�6   $��74��61   $��113,0,0,125.124q�6=   $��1��6V     ButtonStyle6#���  6c   $��Bottom=�6�   $��76.75��6�   $ Scribble��6�   6�   �� 5W      -   5        $��calendarButton��5W   �   $�� ��6   $
��Left=�6   $
��61.5��61   $��197,0,0,119.124q�6?   $��1��6X     ButtonStyle7#���  6e   $��Bottom=�6�   $
��59.5��6�   $ Calendar��6�   6�   �� 5X      -   5        $��journalButton��5X   �   $�� ��6   $
��Left=�6   $��66��61   $��260.5,0,0,114.624q�6=   $��1��6X     ButtonStyle8#���  6e   $��Bottom=�6�   $��63.124��6�   $ Journal��6�   6�   �� 5Y      -   5        $��
callButton��5Y   �   $�� ��6   $
��Left=�6   $��66��61   $��327.624,0,0,119.124q�6=   $��1��6Z     ButtonStyle9#���  6g   $��Bottom=�6�   $��60��6�   $ 	Calls/SMS��6�   6�   �� 5Z   
   -   5        $��
lockButton��5Z   �   $�� ��6   $
��Left=�6   $��75.124��67   $��394,0,0,106q�6G   $��1��6\    	 ButtonStyle11#��� 	 6i   $��Bottom=�6�   $��60.703��6�   $ Lock System��6�   6�   �� 5[      -   5        $��Button2��5[   �   $�� ��6   $
��Left=�6   $��90.627��61   $��	265,8,0,0q�6A    
 ButtonStyle12#��� 
 6T   $	��Top=�6|   $��92.627��6�   $ Configure RSS Feeds��6�   6�   �� 5\   
   -   5        $��
TextBlock1��5\   z   $5��//PersonalDesk;component/Fonts/#SketchFlow Print)�6   $��24(�6Q   $��0,0,32.75,170.124q�6_   $��Hello User!��6�   $ Right=�6�   $
��Wrap=�6�   $��29��6�   $��Bottom=�6�   
�������$��Right=�6  $��1��6  $��283.626��6,   5]      3  -System.Windows.Media.Effects.DropShadowEffect  5^      5`      �� 5a   
   -   5        $��button3��5a   �   $�� ��6   $��59.746��6   $��357.627,16.254,0,0q�6,     ButtonStyle13#���  6H   $	��Top=�6p   $
��Left=�6�   $��56��6�   $ Load RSS feeds��6�   6�   �� 5b   
   $��Right=�6   $��53.864��6,   $��0,0,186.124,35.916q�6<   $��dark_close_button1.png��6X   $
��Fill=�6x   $��Bottom=�6�   $��52.376��6�   $��1��6�   ' J� RenderTransformOrigin$' 0.5,0.5&�6�   $( "Use the slider to set transparency��6�   z�5c      V� 5d      .~�5e      �� �� 5f      �� 5g      ( �� Angle$( 90Q�6   T� 5h      5i      5k      �� 5l   
   $��296,192,288,13q�6   $��pdesklogo.png��6(   $��Uniform=�6?   $	 0.5Q�6Q   �� 5m   
   -   5        $��Button4��5m   �   $�� ��6   $��Right=�6   $��41��68   $��0,138,21.75,0q�6D     ButtonStyle32#���  6[   $	��Top=�6�   $��37.297��6�   $ About��6�   6�   �� 5n   
   -   5        $��Button5��5n   �   $�� ��6   $��Right=�6   $��41��68   $��0,192,21.75,0q�6D     ButtonStyle33#���  6[   $	��Top=�6�   $��37.297��6�   $
 Help��6�   5o      5p      