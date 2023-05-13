function gridDetail(pNombre) {
    this.nombreGD = pNombre;
    this.selector = '';
    this.indice = 0;
    this.lista = '';
    this.agregarCol = function (pNombre, pValor, pVisible = true, pWith = 80) {
        var mostrar = (pVisible == true ? '' : 'hidden');
        return "<td " + mostrar + ">\
                            <input type='text'\
                                   class='border-0 bg-transparent'\
                                   name='" + this.lista + "[index]." + pNombre + "'\
                                   value='" + pValor + "'\
                                   style='width: " + pWith + "px'\
                                   readonly />\
                        </td>";
    }
    this.agregarDetalle = function (pFunc) {
        var domId = "tr" + this.lista + "_" + this.indice;
        var tbody = $("#" + this.selector + " > tbody");
        var tr = "<tr id='" + domId + "'>\
                          " + pFunc(this) + "\
                          <td class='text-center'>\
                              <button type='button' class='btn btn-danger rounded' onclick=\"" + this.nombreGD + ".quitarDetalle('" + domId + "')\"> X </button>\
                          </td>\
                      </tr>";
        tbody.append(tr);
        this.indice++;
        this.serializar();
    }

    this.quitarDetalle = function(domId) {
        $("#" + domId).remove();
        this.serializar();
    }

    this.serializar = function () {
        var filas = $("#" + this.selector + " > tbody > tr");
        if (filas.length > 0) {
            for (var i = 0; i < filas.length; i++) {
                filas[i].innerHTML = filas[i].innerHTML.replaceAll('index', i);
            }
        }
    }

    this.limpiar = function () {
        $("#" + this.selector + " > tbody").html("");
        this.serializar();
    }
    this.bloquear = function () {
        $("#" + this.selector + " > tbody button").attr("disabled", "disabled");
    }
}