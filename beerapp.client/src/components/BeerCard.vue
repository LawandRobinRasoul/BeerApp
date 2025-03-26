<template>
  <div class="modal-overlay" @click.self="close">
    <div class="modal-content">
      <button class="close-button" @click="close">X</button>
      <img :src="beer.image" alt="Beer Image" class="beer-image" />
      <h3>{{ beer.name }}</h3>
      <p>Rating: {{ beer.rating }}</p>
      <p>{{ beer.description }}</p>

      <!-- Sliders for rating -->
      <div class="rating-section">
        <div class="rating-item">
          <label for="bitterness">Bitterness: {{ ratings.bitterness }}</label>
          <input
            id="bitterness"
            type="range"
            min="1"
            max="5"
            v-model="ratings.bitterness"
          />
        </div>
        <div class="rating-item">
          <label for="sweetness">Sweetness: {{ ratings.sweetness }}</label>
          <input
            id="sweetness"
            type="range"
            min="1"
            max="5"
            v-model="ratings.sweetness"
          />
        </div>
        <div class="rating-item">
          <label for="fruitiness">Fruitiness: {{ ratings.fruitiness }}</label>
          <input
            id="fruitiness"
            type="range"
            min="1"
            max="5"
            v-model="ratings.fruitiness"
          />
        </div>
      </div>

      <!-- Review Textbox -->
      <div class="review-section">
        <label for="review">Write a Review:</label>
        <textarea
          id="review"
          v-model="review"
          placeholder="Write your review here..."
        ></textarea>
      </div>

      <!-- Rate Button -->
      <button class="rate-button" @click="submitRating">Rate</button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps, defineEmits, reactive, ref } from 'vue';

const props = defineProps({
  beer: {
    type: Object,
    required: true,
  },
});

const emit = defineEmits(['close']);

const close = () => {
  emit('close');
};

// Reactive object to store ratings
const ratings = reactive({
  bitterness: 5,
  sweetness: 5,
  fruitiness: 5,
});

// Review text
const review = ref('');

// Method to handle rating submission
const submitRating = () => {
  console.log('Rating submitted:', { ...ratings, review: review.value });
};
</script>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
}

.modal-content {
  background: white;
  padding: 20px;
  border-radius: 8px;
  width: 300px;
  text-align: center;
  position: relative;
}

.close-button {
  position: absolute;
  top: 10px;
  right: 10px;
  background: none;
  border: none;
  font-size: 16px;
  cursor: pointer;
}

.beer-image {
  width: 100%;
  height: 150px;
  object-fit: cover;
  border-radius: 4px;
}

.rating-section {
  margin-top: 20px;
}

.rating-item {
  margin-bottom: 15px;
}

.rating-item label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

.rating-item input[type='range'] {
  width: 100%;
}

.review-section label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

.review-section textarea {
  width: 100%;
  height: 60px;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
  resize: none;
}

.rate-button {
  margin-top: 20px;
  padding: 10px 20px;
  background-color: #003366;
  color: #ffd700;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-weight: bold;
}

.rate-button:hover {
  background-color: #00274d;
}
</style>