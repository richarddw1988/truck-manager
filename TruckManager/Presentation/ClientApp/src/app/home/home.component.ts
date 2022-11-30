import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public trucks: TruckViewModel[] = [];
  public truck!: TruckViewModel;
  public modelos: ModeloViewModel[] = [];
  
  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    this.truck = new TruckViewModel();
    this.carregarCaminhoes();
    this.carregarModelos();
  }

  onChangeCheckbox(event: any, id: number) {
    if (event.target.checked) {
      this.trucks.map(truck => {
        if (truck.id !== id) {
          truck.selecionado = false;
        } else {
          this.truck = Object.assign(this.truck, truck);
        }
      });
    } else {
      this.truck = new TruckViewModel();
    }
  }

  successNotification(title: string, message: string) {
    Swal.fire(title, message, 'success');
  }

  errorNotification(title: string, message: string) {
    Swal.fire(title, message, 'error');
  }

  carregarModelos() {
    this.http.get<ModeloViewModel[]>(this.baseUrl + 'api/modelo')
      .subscribe(result => {
        this.modelos = result;
      }, (error) => {
        this.errorNotification('', error.error);
        console.error(error)
      });
  }


  carregarCaminhoes() {
    this.http.get<TruckViewModel[]>(this.baseUrl + 'api/truck')
      .subscribe(result => {
        this.trucks = result;
      }, (error) => {
        this.errorNotification('', error.error);
        console.error(error)
      });
  }

  onClickIncluir() {
    this.http.post(this.baseUrl + 'api/truck', this.truck)
      .subscribe(() => {
        this.carregarCaminhoes();
        this.truck = new TruckViewModel();
        this.successNotification('', 'Incluido com sucesso!');
      }, (error) => {
        this.errorNotification('', error.error);
        console.error(error)
      });
  }

  onClickExcluir() {
    this.http.delete(this.baseUrl + `api/truck/${this.truck.id}`)
      .subscribe(() => {
        this.carregarCaminhoes();
        this.truck = new TruckViewModel();
        this.successNotification('', 'Exclído com sucesso!');
      }, (error) => {
        this.errorNotification('', error.error);
        console.error(error)
      });
  }

  onClickAtualizar() {
    this.http.put(this.baseUrl + `api/truck/${this.truck.id}`, this.truck)
      .subscribe(() => {
        this.carregarCaminhoes();
        this.truck = new TruckViewModel();
        this.successNotification('', 'Atualizado com sucesso!');
      }, (error) => {
        this.errorNotification('', error.error);
        console.error(error)
      });
  }
}


class ModeloViewModel {
  id: number = 0;
  nome: string = "";
}

class TruckViewModel {
  selecionado: boolean = false;
  id: number = 0;
  nome: string = "";
  idModelo: number = 0;
  modelo: string = "";
  anoFabricacao: number = 2022;
  anoModelo: number = 2022;
}
