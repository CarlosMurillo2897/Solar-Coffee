<template>
  <solar-modal>
    <template v-slot:header> Add New Product </template>
    <template v-slot:body>
      <ul class="newProduct">
        <li>
          <label for="isTaxable">Is this product taxable?</label>
          <input
            type="checkbox"
            id="isTaxable"
            v-model="newProduct.isTaxable"
          />
        </li>
        <li>
          <label for="productName">Name</label>
          <input type="text" id="productName" v-model="newProduct.name" />
        </li>
        <li>
          <label for="productDesc">Description</label>
          <input
            type="text"
            id="productDesc"
            v-model="newProduct.description"
          />
        </li>
        <li>
          <label for="productPrice">Price (USD)</label>
          <input type="number" id="productPrice" v-model="newProduct.price" />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <solar-button
        type="button"
        @click.native="save"
        aria-label="Save New Item"
      >
        Save Product
      </solar-button>
      <solar-button
        type="button"
        @click.native="close"
        aria-label="Close Modal"
      >
        Close
      </solar-button>
    </template>
  </solar-modal>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

// Components.
import SolarButton from "@/components/SolarButton.vue";
import SolarModal from "@/components/modals/SolarModal.vue";

// Types.
import { IProduct } from "@/types/Product";

@Component({
  name: "NewProductModal",
  components: { SolarButton, SolarModal },
})
export default class NewProductModal extends Vue {
  newProduct: IProduct = {
    createdOn: new Date(),
    updatedOn: new Date(),
    id: 0,
    description: "",
    isTaxable: false,
    name: "",
    price: 0,
    isArchived: false,
  };

  close(): void {
    this.$emit("close");
  }

  save(): void {
    this.$emit("save:product", this.newProduct);
  }
}
</script>

<style scoped lang="scss">
.newProduct {
  list-style: none;
  padding: 0;
  margin: 0;
}

#isTaxable {
  width: 5%;
}
</style>