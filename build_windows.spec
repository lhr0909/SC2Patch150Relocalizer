# -*- mode: python -*-
a = Analysis(['SimonsRelocalizerPython\\Relocalizer.py'],
             pathex=['D:\\development\\SC2Patch150Relocalizer'],
             hiddenimports=[],
             hookspath=None)
pyz = PYZ(a.pure)
exe = EXE(pyz,
          a.scripts,
		  Tree("D:\\development\\SC2Patch150Relocalizer\\SimonsRelocalizerPython\\resources"),
          a.binaries,
          a.zipfiles,
          a.datas,
          name=os.path.join('dist', 'SimonsRelocalizer.exe'),
          debug=False,
          strip=None,
          upx=True,
          console=False , icon='SimonsRelocalizerPython\\resources\\SC2-SimonsRelocalizer.ico')
app = BUNDLE(exe,
             name=os.path.join('dist', 'SimonsRelocalizer.exe.app'))
