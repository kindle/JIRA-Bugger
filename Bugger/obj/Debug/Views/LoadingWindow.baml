   M S B A M L   `   `   `  ����  
JiraBugger    JiraBugger.LoadingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  LoadingWindow��5   	   $��50��6   $	��100��6+    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�6    � AllowsTransparency . 
������  � Topmost .  � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=�5   .    � 	Resources 5         LoadingStoryboard W� From		 W� To
 g� Duration �� 
TargetName �� TargetProperty��%�   &	        �� 5   
   .��5	      W� $ 1X�6   $	 1X�6'   $
 0:0:2D�6.   $ MyBorder��6?   $ Opacity�6`   5
      5      .��5      �� -   5         ��Name$ MyBorder��5   A    �� CornerRadius$ 3��6    J� Opacity$	 0.9Q�6   ���#B3d66e._�5   
   �� $��Center=�6   $��Center=�61   
Loading...6X   5      5      