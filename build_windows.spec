# -*- mode: python -*-
a = Analysis(['SimonsRelocalizerPython\\RelocalizerUI.py'],
             pathex=['C:\\Users\\Simon\\Desktop\\development\\SC2Patch150Relocalizer'],
             hiddenimports=[],
             hookspath=None)
pyz = PYZ(a.pure)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          name=os.path.join('dist', 'RelocalizerUI.exe'),
          debug=False,
          strip=None,
          upx=True,
          console=False , icon='C:\\Users\\Simon\\Desktop\\development\\SC2Patch150Relocalizer\\SimonsRelocalizerPython\\resources\\SC2-SimonsRelocalizer.ico')
app = BUNDLE(exe,
             name=os.path.join('dist', 'RelocalizerUI.exe.app'))
