cd D:\development\SC2Patch150Relocalizer\
D:
pyinstaller-2.0\utils\Makespec.py --noconsole --onefile --icon="SimonsRelocalizerPython\resources\SC2-SimonsRelocalizer.ico" --name="SimonsRelocalizer" SimonsRelocalizerPython\Relocalizer.py
del build_windows.spec
ren "SimonsRelocalizer.spec" build_windows.spec