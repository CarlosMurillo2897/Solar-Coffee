<template>
  <solar-modal>
    <template v-slot:header> Receive Shipment </template>
    <template v-slot:body>
      <label for="product">Product Received: </label>
      <select v-model="selectedProduct" id="product" class="shipmentItems">
        <option value="" disabled>Please select one</option>
        <option v-for="item in inventory" :value="item" :key="item.product.id">
          {{ item.product.name }}
        </option>
      </select>
      <label for="qtyReceived">Quantity Received: </label>
      <input type="number" id="qtyReceived" v-model="qtyReceived" />
    </template>
    <template v-slot:footer>
      <solar-button
        type="button"
        @button:click="save"
        aria-label="Save new Shipment"
      >
        Save Received Shipment
      </solar-button>
      <solar-button
        type="button"
        @button:click="close"
        aria-label="Close modal"
      >
        Close
      </solar-button>
    </template>
  </solar-modal>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

// Components.
import SolarButton from "@/components/SolarButton.vue";
import SolarModal from "@/components/modals/SolarModal.vue";

// Types.
import { IProduct } from "@/types/Product";
import { IShipment } from "@/types/Shipment";
import { IProductInventory } from "@/types/ProductInventory";

@Component({
  name: "ShipmentModal",
  components: { SolarButton, SolarModal },
})
export default class ShipmentModal extends Vue {
  @Prop({ required: true, type: Array as () => IProductInventory[] })
  inventory!: IProductInventory[];

  selectedProduct: IProduct = {
    createdOn: new Date(),
    updatedOn: new Date(),
    id: 0,
    description: "",
    isTaxable: false,
    name: "",
    price: 0,
    isArchived: false,
  };

  qtyReceived = 0;

  close(): void {
    this.$emit("close");
  }
  
  save(): void {
    let shipment: IShipment = {
      productId: this.selectedProduct.id,
      adjustment: this.qtyReceived
    };

    this.$emit("save:shipment", shipment);
  }
}
</script>
