   M S B A M L   `   `   `  ���� 	  Winky     WpfApplication1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  locationWindow�� � Title$ Winky��$	��570��$��277.0�� � 
ResizeMode$ NoResize=� � ShowInTaskbar .  
���  ��.��� -    �Name$
 grid��$��0,0,0,-3q�.+��� -    ��Name$ 	imgCloudy��$��141,437,0,0q�$��94��$	��Top=�$
��Left=�$��87������  �� DecodePixelWidth$ 70�� �� 	UriSource$  ?�� -   $��cpuUsage��$��21��$
��Left=�$��
126,96,0,0q�$	��Top=�$	��120�����	#FF35B5E5�� -   $��cancel��$��X��$��12��$
��Left=�$��
263,0,-6,0q�$	��Top=�$��14��$��6(����	#FF35B5E5�� -    ��Name$ 	txtNetOut��$��23��$��126,208,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$
��Left=�$	��120�����	#FFD1D1D1�� -   $ txtNetIn��$
��Left=�$��23��$��126,180,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $ txtExternal��$��23��$��126,320,0,0q�$
	 Wrap=�$	��Top=�$
��Left=�$	��120�����	#FFD1D1D1�� -	   $ txtLocal��$��23��$��126,348,0,0q�$
	 Wrap=�$	��Top=�$
��Left=�$	��120�����	#FFD1D1D1�� -
   
 ��Name$
 lblCPU��$��
CPU Load :��$
��Left=�$��	54,70,0,0q�$	��Top=��� -   $
 lblNetIn��$��Data Receiving :��$
��Left=�$��
26,179,0,0q�$	��Top=��� -   $
 	lblNetOut��$��Data Sending :��$
��Left=�$��
34,207,0,0q�$	��Top=��� -   $
 lblExternalIP��$��External IP :��$
��Left=�$��
50,318,0,0q�$	��Top=��� -   $
 
lblLocalIP��$��
Local IP :��$
��Left=�$��
65,346,0,0q�$	��Top=��� -   $ txtRam��$
��Left=�$��23��$��126,123,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $
 lblRam��$��
Free RAM :��$
��Left=�$��
54,121,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.737,0.269&��� -   $ txtRamPercent��$
��Left=�$��23��$��126,151,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1.�� J� OpacityMask ��  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ White��$ 1Q�.���� -   $
 lblRamPercent��$��
Used RAM :��$
��Left=�$��
49,149,0,0q�$	��Top=��� -   $ txtDriveSpace��$
��Left=�$��23��$��126,377,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $
 lblDiskSpace��$��Free Space :��$
��Left=�$��
48,376,0,0q�$	��Top=��� -   $
 lblTotalReceived��$��Total Data Received :��$
��Left=�$��
-1,235,0,0q�$	��Top=�$	��122���� -   $ txtTotalReceived��$
��Left=�$��23��$��126,237,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $
 lblTotalSent��$��Total Data Sent :��$
��Left=�$��
24,263,0,0q�$	��Top=�$ 0.026,-0.462&��� -   $ txtTotalSent��$
��Left=�$��23��$��126,265,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $ txtPing��$
��Left=�$��23��$��126,293,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $
 lblPing��$��Ping :��$
��Left=�$��
82,292,0,0q�$	��Top=��� -    ��Name$ 	txtAvgBox��$
��Left=�$��
126,75,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -0.663Q�T� �� -   $
 
lblUpdates��$��Available Updates :��$
��Left=�$��
10,402,0,0q�$	��Top=��� -   $ 
txtWeather��$
��Left=�$��83��$��
10,446,0,0q�$
	 Wrap=�$	��Top=�$	��251��$��0q���Z� �� -   $ 
txtUpdates��$
��Left=�$��24��$��126,405,0,0q�$
	 Wrap=�$	��Top=�$	��120�����	#FFD1D1D1�� -   $ txtTime��$
��Left=�$
��Wrap=�$	��Top=�$
��Time��$��3,5,0,0q��� -    $
 
lblSysInfo��$��  System Information��$��0,21,0,0q�$	��Top=�$��Center=�$��30��$��16(�$
��Bold"����	#FF35B5E5