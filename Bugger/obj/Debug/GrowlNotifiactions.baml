   M S B A M L   `   `   `  ����A  =Bugger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BuggerBugger  5   	       Bugger.GrowlNotifiactions   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &Modelclr-namespace:Bugger     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  GrowlNotifiactions��5   	   $	��530��6$   $	��300��61    � ShowActivated .   � AllowsTransparency .  � WindowStyle$
 None=�6m    � ShowInTaskbar .  
������  � Topmost .  � UseLayoutRounding .  � 	Resources 5         NormalBorderBrush �� Color  DefaultedBorderBrush  DisabledForegroundBrush  DisabledBackgroundBrush  DisabledBorderBrush  WindowBackgroundBrush  SelectedBackgroundBrush  ButtonFocusVisual	 �� Property
 �� Value �� StrokeDashArray  CloseNormal �� 
StartPoint �� EndPoint � Color � Offset 	 	CloseOver 
 ClosePressed  CloseButton �� 
TargetType �� 
TargetType ��Name �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity   
BlurRadius   Color J� IsHitTestVisible   	Direction �� Triggers P� Property P� Value �� 
TargetName  CollapseStoryboard W� From	  W� To! �� TargetProperty" g� Duration  MessageTemplate# �� DataType$ �Name
% � Tag& �� Path' � RowDefinitions( � ColumnDefinitions&   System.Windows.Media.TextOptions)   TextRenderingMode*   TextFormattingMode+ ��Name, �� Triggers- :� RoutedEvent. :� 
SourceName/ ��Name0 �� 
TargetName1 g� 	BeginTime2 N� EnterActions3 �� Offset4 �� BeginStoryboardName5 N� ExitActions6 P� 
SourceName��%�  &	        &	      &	 >     &	 \     &	 z     &	 �     &	 �     &	 �     &	 �    &		 >    &	
 �    &	 �    7  7  7   7 	 7 
 7  7  7  7  7  &	 �    &	 �    7  7  �� 5	   
   $ Black��64   �� 5
   
   $ Black��67   �� 5   
   $
 #888��6:   �� 5   
   $
 #EEE��6:   �� 5   
   $
 #AAA��66   �� 5   
   $
 #FFF��68   �� 5   
   $
 #DDD��6:   �� 5   
   .�5      �� 	 � ��
 5      �� 5      .R�5      �� ._�5      �� $��2q�5      $��1��5      ���	#60000000$	 1 2R�5      5      5      5      5      �� 5    
   $ 0.5,0&�62   $ 0.5,1&�6E   .��5!      � $ #394452��6   $	 0.0Q�6+   � 5"      $ #343e4a��6   $	 1.0Q�6+   5#      �� 5$   
   $ 0.5,0&�60   $ 0.5,1&�6C   .��5%      � $ #515a6b��6   $	 0.0Q�6+   � 5&      $ #474f5d��6   $	 1.0Q�6+   5'      �� 5(   
   $ #090909��6/   �� 5*   
   " ��6$   .�5+      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5,      	 �@�OverridesDefaultStyle
 . 66   �� 5-      	 �@�FocusVisualStyle8
   61   �� 5.      	 � ��$
 16��6*   �� 5/      	 � ��$
 16��6)   �� 50      	 �@�Cursor$

 Hand��6'   �� 51      	 � ��
 52      �� 53      " ��6&   .R�54      � .+�55      �� $ Border��6%   $ 3��65   $��0q�6F   }�.  8�� 8��  56   "     57   &   $ 0Q�67   $ .4Q�6G   $ 5Q�6T   $ Black��6c   ._�59   "   � .+�5:   &   �� $0��*pack://application:,,,/Resources/close.png��6,    .  $��2q�6y    5;   *     5<   .   $ 90Q�6?   $ 1Q�6N   $ 1Q�6^   5>   '   �� 5?   &   $��Center=�67   $��Center=�6T   ��. 6o   5@   #   5A      5B       5C      P� 5D       �@J�IsMouseOver . . �5E   "   �� $ Border��6)   8
  	 � ��6S   5F      P� 5G       � �� . . �5H   "   �� $ Border��6)   8
  	 � ��6S   5I      P� 5J       �@J�IsKeyboardFocused . . �5K   "   �� $ Border��6)   8
  	 � ��6T   5L      P� 5M       �@��IsDefaulted . . �5N   "   �� $ Border��6)   8
  	 � ��6T   5O      P� 5P       � {� .  . �5Q   "   �� $ Border��6)   8
  	 � ��6S   �� 5R   "   $ Border��6)   8
  	 � ��6T   �� 5S   "   8
 	 	 � ��6?   5T      5V      5X      5Y      �� 5Z   
   .��5[      W� $	 100X�6   $  0X�6)   $! Height�60   $" 0:0:1D�6S   5\      �� 5]   
   $# Model:Notification��6/   .R�5^      � $$ NotificationWindow��6   -   5        
������ % 5^   /   �� $& Id�.+�5_      �� $��border��6   ���#2a3345$��0q�6<   $ 10��6P   $��10q�6b    5`        5a      $ 0Q�6+   $	 0.8Q�6;   $ 10Q�6I   ._�5c      � $��50��6   $	��280��6'   $��6q�63   ' 5d      �� 5e      $
��Auto �6,   6<   �� 5f      $��* �6,   69   ( 5h      �� 5i      $
��Auto �6/   6>   �� 5j      $��* �6/   6;   .+�5l      �� $��2��6    $��4q�6R   $��48��6]   ��61   �� $& ImageUrl�6j   �� 5m      -   5        $��1��5m   !   % 6E   �� $& Message���5n      �� 5o   "   .R�5p   &   �� $) 	ClearType=�6L   $* Display=�5q   0   
�������$��Arial)�5r   $   $��14(�67   $
��Bold"�6E   $��Center=�6W   $��2,4,4,2q�6s   $
��Wrap=�6�   $��CharacterEllipsis=�6�   ��5p   0   �� $& Title�5r   �   5s   #   5u      �� 5v      $+ CloseButton��6!   $��1��66   $��16��6F   $��16��6Q   $��Right=�6]   $��0,0,12,0q�6y   8��  6�   �� 5w      -   5        $��1��5w   !   $��1��6.   % 6T   �� $& Message���5x      �� 5y   "   .R�5z   &   �� $) 	ClearType=�6O   $* Display=�6y   
�������$��Arial)�5{   $   $��Center=�67   $��2,2,4,4q�6S   $
��Wrap=�6d   $��CharacterEllipsis=�6x   ��5z   0   �� $& Message�5{   x   5|   #   5~      5      5�      5�      , 5�      :� 5�      $- Window.Loaded��6   $. NotificationWindow��6;   .[�5�      �� $/ FadeInStoryBoard��6&   .��5�      �� .��5�      W� $0 NotificationWindow��6.   $
 0.01X�6Y   $  1X�6e   $! Opacity�6l   $" 0:0:2D�6�   W� 5�      $0 NotificationWindow��6.   $ 1X�6Y   $  0X�6b   $! Opacity�6i   $" 0:0:2D�6�   $1 0:0:6X�6�   5�      5�      5�      P� 5�       �@J�IsMouseOver . 2 5�      �� 5�      $3 0:0:3h�6)   $4 FadeInStoryBoard��68   ?� 5�      $4 FadeInStoryBoard��6*   5 5�      �� 5�      $3 0:0:3h�6)   $4 FadeInStoryBoard��68   �� 5�      $4 FadeInStoryBoard��6+   6T   5�      :� 5�      $- Button.Click��6   $. CloseButton��6:   .[�5�      �� .��5�      �� .��5�      W� $0 NotificationWindow��6.   $ 1X�6Y   $  0X�6b   $! (Grid.Opacity)�6i   $" 0:0:0D�6�   5�      5�      5�      P� 5�      $6 NotificationWindow��6    �@J�Opacity$ 0Q�6M   . �5�      �� $ NotificationWindow��6   	 � y�$
 Hidden=�6S   6d   2 5�      �� 5�      8�� 6*   5�      5�      5�      .��5�      �� -   5        7 ��Name$7 NotificationsControl��5�      #��[ 6g   8 � FocusVisualStyle8 61   Z� ��6M   �� *.+6g   5�      