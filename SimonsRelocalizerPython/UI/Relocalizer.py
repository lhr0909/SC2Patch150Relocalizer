import sys
from PyQt4 import QtCore, QtGui

from Relocalizer_ui import Ui_RelocalizerMain


class SimonsRelocalizer(QtGui.QMainWindow):
    def __init__(self, parent=None):
        QtGui.QWidget.__init__(self, parent)
        self.ui = Ui_RelocalizerMain()
        self.ui.setupUi(self)


if __name__ == "__main__":
    app = QtGui.QApplication(sys.argv)
    myapp = SimonsRelocalizer()
    myapp.show()
    sys.exit(app.exec_())