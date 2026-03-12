<script setup lang="ts">
import MemberCheck from './MemberCheck.vue';
import NoticeCheck from './NoticeCheck.vue';


const loading = ref(false)
const Member = ref(null)
const Notice = ref(null)
</script>

<template>

    <button class="btn btn-primary" onclick="my_modal_1.showModal()">
        <Icon name="lucide:circle-plus" size="24px" />
        Ajouter un pret
    </button>
    <dialog id="my_modal_1" class="modal">
        <div class="modal-box">
            <h3 class="text-lg font-bold">Inserer un nouveau pret</h3>
            <div class="mt-4 space-y-2 flex  flex-col justify-center items-start">

                <div class="bg-blue- w-full">
                    <label class="label">Numero carte de l'adherent</label>
                    <div class="flex justify-between w-full">
                        <input class="input w-full" />

                        <button class="btn ml-2 w-32">
                            <Icon v-if="loading" name="lucide:loader-circle" size="24px" class="animate-spin" />
                            <p>
                                Verifier
                            </p>
                        </button>
                    </div>
                </div>
                <MemberCheck name="FADEL AKRAM" :authorized="true" />
                <div class="bg-blue- w-full">
                    <label class="label">Numero de cote</label>
                    <div class="flex justify-between w-full">
                        <input class="input w-full" />
                        <button class="btn ml-2  w-32">
                            <Icon v-if="loading" name="lucide:loader-circle" size="24px" class="animate-spin" />
                            <p>
                                Chercher
                            </p>
                        </button>
                    </div>
                </div>
                <NoticeCheck class="w-full" title="Homeland" :available="true" />
                <div class="text-lg w-full grid grid-cols-2 ">
                    <span> Date de pret : </span> <span class="font-bold">12-03-2026</span>
                    <span>Date de retour: </span> <span class="font-bold">01-04-2026</span>
                </div>
            </div>
            <div class="modal-action">

                <form method="dialog">
                    <button class="btn">
                        Fermer
                    </button>
                </form>
                <button class="btn btn-primary">
                    Inserer
                </button>
            </div>
        </div>

    </dialog>
</template>