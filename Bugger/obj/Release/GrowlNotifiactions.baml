   M S B A M L   `   `   `  ���� A  =Bugger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BuggerBugger      Bugger.GrowlNotifiactions   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &Modelclr-namespace:Bugger     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  GrowlNotifiactions��$	��530��$	��300�� � ShowActivated .   � AllowsTransparency .  � WindowStyle$
 None=� � ShowInTaskbar .  
������  � Topmost .  � UseLayoutRounding .  � 	Resources    NormalBorderBrush �� Color  DefaultedBorderBrush  DisabledForegroundBrush  DisabledBackgroundBrush  DisabledBorderBrush  WindowBackgroundBrush  SelectedBackgroundBrush  ButtonFocusVisual	 �� Property
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
SourceName��%�  &	        &	      &	 "     &	 2     &	 B     &	 R     &	 b     &	 r     &	 �     &		 %    &	
     &	 �    7  7  7   7 	 7 
 7  7  7  7  7  &	 �    &	 #    7  7  �� $ Black���� $ Black���� $
 #888���� $
 #EEE���� $
 #AAA���� $
 #FFF���� $
 #DDD���� .��� 	 � ��
 �� .R��� ._��� $��2q�$��1�����	#60000000$	 1 2R��� $ 0.5,0&�$ 0.5,1&�.��� $ #394452��$	 0.0Q�� $ #343e4a��$	 1.0Q��� $ 0.5,0&�$ 0.5,1&�.��� $ #515a6b��$	 0.0Q�� $ #474f5d��$	 1.0Q��� $ #090909���� " ��.��� 	 �@J�SnapsToDevicePixels
 . �� 	 �@�OverridesDefaultStyle
 . �� 	 �@�FocusVisualStyle8
   �� 	 � ��$
 16���� 	 � ��$
 16���� 	 �@�Cursor$

 Hand���� 	 � ��
 �� " ��.R�� .+��� $ Border��$ 3��$��0q�}�.  8�� 8��    $ 0Q�$ .4Q�$ 5Q�$ Black��._�� .+��� $0��*pack://application:,,,/Resources/close.png�� .  $��2q�   $ 90Q�$ 1Q�$ 1Q��� $��Center=�$��Center=���.  P�  �@J�IsMouseOver . . ��� $ Border��8
  	 � ��P�  � �� . . ��� $ Border��8
  	 � ��P�  �@J�IsKeyboardFocused . . ��� $ Border��8
  	 � ��P�  �@��IsDefaulted . . ��� $ Border��8
  	 � ��P�  � {� .  . ��� $ Border��8
  	 � ���� $ Border��8
  	 � ���� 8
 	 	 � ���� .��W� $	 100X�$  0X�$! Height�$" 0:0:1D��� $# Model:Notification��.R�� $$ NotificationWindow��-   
������ % �� $& Id�.+��� $��border�����#2a3345$��0q�$ 10��$��10q�   $ 0Q�$	 0.8Q�$ 10Q�._�� $��50��$	��280��$��6q�' �� $
��Auto ��� $��* �( �� $
��Auto ��� $��* �.+��� $��2��$��4q�$��48������ $& ImageUrl��� -   $��1��% �� $& Message����� .R��� $) 	ClearType=�$* Display=�
�������$��Arial)�$��14(�$
��Bold"�$��Center=�$��2,4,4,2q�$
��Wrap=�$��CharacterEllipsis=����� $& Title��� $+ CloseButton��$��1��$��16��$��16��$��Right=�$��0,0,12,0q�8��  �� -   $��1��$��1��% �� $& Message����� .R��� $) 	ClearType=�$* Display=�
�������$��Arial)�$��Center=�$��2,2,4,4q�$
��Wrap=�$��CharacterEllipsis=����� $& Message�, :� $- Window.Loaded��$. NotificationWindow��.[��� $/ FadeInStoryBoard��.���� .��W� $0 NotificationWindow��$
 0.01X�$  1X�$! Opacity�$" 0:0:2D�W� $0 NotificationWindow��$ 1X�$  0X�$! Opacity�$" 0:0:2D�$1 0:0:6X�P�  �@J�IsMouseOver . 2 �� $3 0:0:3h�$4 FadeInStoryBoard��?� $4 FadeInStoryBoard��5 �� $3 0:0:3h�$4 FadeInStoryBoard���� $4 FadeInStoryBoard��:� $- Button.Click��$. CloseButton��.[��� .���� .��W� $0 NotificationWindow��$ 1X�$  0X�$! (Grid.Opacity)�$" 0:0:0D�P� $6 NotificationWindow�� �@J�Opacity$ 0Q�. ��� $ NotificationWindow��	 � y�$
 Hidden=�2 �� 8�� .���� -   7 ��Name$7 NotificationsControl��#��[ 8 � FocusVisualStyle8 Z� ���� *.+