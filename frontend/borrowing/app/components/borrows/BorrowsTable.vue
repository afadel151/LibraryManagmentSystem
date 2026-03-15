<script setup lang="ts">

interface Borrow {
    id: string
    nom: string
    categorie: string
    titre_notice: string
    cote: string
    date_pret: string
    date_retour: string
}

const borrows = ref<Borrow[]>([])
const total = ref(0)

const sortKey = ref<string>('')
const sortOrder = ref<'asc' | 'desc'>('asc')

const pageSize = ref(10)
const currentPage = ref(1)
const pageSizeOptions = [5, 10, 20, 50]

const columns: { key: keyof Borrow; label: string }[] = [
    { key: 'nom', label: 'Nom d\'adherent' },
    { key: 'categorie', label: 'Categorie' },
    { key: 'titre_notice', label: 'Titre de notices' },
    { key: 'cote', label: 'Cote' },
    { key: 'date_pret', label: 'Date de pret' },
    { key: 'date_retour', label: 'Date de retour' },
]

const sampleBorrows: Borrow[] = [
  {
    id: '1',
    nom: 'Alice Dupont',
    categorie: 'Science',
    titre_notice: 'Astronomy Basics',
    cote: 'QA76.73.A1 D87',
    date_pret: '2026-03-01',
    date_retour: '2026-03-15'
  },
  {
    id: '2',
    nom: 'Bob Martin',
    categorie: 'Literature',
    titre_notice: 'Les Misérables',
    cote: 'PQ2286 .M37 1862',
    date_pret: '2026-02-25',
    date_retour: '2026-03-10'
  },
  {
    id: '3',
    nom: 'Clara Nguyen',
    categorie: 'Math',
    titre_notice: 'Linear Algebra Explained',
    cote: 'QA184 .N84 2020',
    date_pret: '2026-03-05',
    date_retour: '2026-03-20'
  },
  {
    id: '4',
    nom: 'David Lopez',
    categorie: 'History',
    titre_notice: 'World War II',
    cote: 'D743 .L65 2018',
    date_pret: '2026-03-02',
    date_retour: '2026-03-17'
  },
  {
    id: '5',
    nom: 'Emma Rossi',
    categorie: 'Science',
    titre_notice: 'Physics for Beginners',
    cote: 'QC21.3 .R67 2019',
    date_pret: '2026-03-06',
    date_retour: '2026-03-21'
  },
  {
    id: '6',
    nom: 'Frank Zhang',
    categorie: 'Technology',
    titre_notice: 'Introduction to AI',
    cote: 'Q335 .Z43 2021',
    date_pret: '2026-03-07',
    date_retour: '2026-03-22'
  },
  {
    id: '7',
    nom: 'Grace Kim',
    categorie: 'Science',
    titre_notice: 'Chemistry 101',
    cote: 'QD31 .K56 2017',
    date_pret: '2026-03-03',
    date_retour: '2026-03-18'
  },
  {
    id: '8',
    nom: 'Hugo Fernandez',
    categorie: 'Math',
    titre_notice: 'Calculus Made Easy',
    cote: 'QA303 .F47 2016',
    date_pret: '2026-03-04',
    date_retour: '2026-03-19'
  },
  {
    id: '9',
    nom: 'Hugo Fernandez',
    categorie: 'Math',
    titre_notice: 'Calculus Made Easy',
    cote: 'QA303 .F47 2016',
    date_pret: '2026-03-04',
    date_retour: '2026-03-19'
  },
  {
    id: '10',
    nom: 'Hugo Fernandez',
    categorie: 'Math',
    titre_notice: 'Calculus Made Easy',
    cote: 'QA303 .F47 2016',
    date_pret: '2026-03-04',
    date_retour: '2026-03-19'
  }
]
const totalPages = computed(() =>
    Math.max(1, Math.ceil(total.value / pageSize.value))
)

// fetch boorows 
async function fetchBorrows() {
    // const res: any = await $fetch('/api/borrows', {
    //     params: {
    //         page: currentPage.value,
    //         page_size: pageSize.value,
    //         attribute: sortKey.value,
    //         order: sortOrder.value
    //     }
    // })

    borrows.value = sampleBorrows
    total.value = sampleBorrows.length
}

function toggleSort(key: string) {
    if (sortKey.value === key) {
        sortOrder.value = sortOrder.value === 'asc' ? 'desc' : 'asc'
    } else {
        sortKey.value = key
        sortOrder.value = 'asc'
    }

    currentPage.value = 1
}

function goToPage(page: number) {
    currentPage.value = Math.min(Math.max(1, page), totalPages.value)
}

function onPageSizeChange(e: Event) {
    const target = e.target as HTMLSelectElement
    pageSize.value = Number(target.value)
    currentPage.value = 1
}

watch([currentPage, pageSize, sortKey, sortOrder], fetchBorrows, {
    immediate: true
})

const visiblePages = computed(() => {
    const totalP = totalPages.value
    const current = currentPage.value
    const delta = 2

    const pages = []

    for (let i = Math.max(1, current - delta); i <= Math.min(totalP, current + delta); i++) {
        pages.push(i)
    }

    return pages
})

</script>

<template>
    <div class="w-full mt-5 p-2 rounded-box border border-base-content/5 bg-base-100">
        <table class="table">
            <thead>
                <tr>
                    <th v-for="col in columns" :key="col.key" class="cursor-pointer select-none whitespace-nowrap"
                        @click="toggleSort(col.key)">
                        <p class="inline-flex justify-between w-full items-center gap-1">
                            <span>

                                {{ col.label }}
                            </span>
                            <Icon name="lucide:chevron-up" v-if="sortKey === col.key && sortOrder === 'asc'"
                                size="16px" />
                            <Icon name="lucide:chevron-down" v-else-if="sortKey === col.key && sortOrder === 'desc'"
                                size="16px" />
                            <Icon name="lucide:chevrons-up-down" v-else size="16px" class="opacity-55" />
                        </p>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="borrow in borrows" :key="borrow.id" class="hover:bg-base-200">
                    <td v-for="col in columns" :key="col.key">
                        {{ borrow[col.key] ?? '-' }}
                    </td>
                </tr>

            </tbody>
        </table>
        <div class="flex items-center justify-between mt-3 gap-2 flex-wrap">
            <div class="flex items-center gap-2 text-sm text-muted-foreground">
                <span>Rows per page</span>
                <select :value="pageSize" class="rounded border px-2 py-1 text-sm bg-background"
                    @change="onPageSizeChange">
                    <option v-for="n in pageSizeOptions" :key="n" :value="n">{{ n }}</option>
                </select>
            </div>

            <div class="flex items-center gap-1 text-sm">
                <span class="text-muted-foreground mr-2">
                    {{ borrows.length === 0 ? '0' : (currentPage - 1) * pageSize + 1 }}–{{ Math.min(currentPage *
                        pageSize, borrows.length) }}
                    of {{ borrows.length }}
                </span>

                <Button variant="outline" size="icon" :disabled="currentPage === 1" @click="goToPage(currentPage - 1)">
                    <ChevronLeft class="h-4 w-4" />
                </Button>


                <Button v-for="page in visiblePages" :key="page"
                    :variant="page === currentPage ? 'secondary' : 'outline'" size="icon" @click="goToPage(page)">
                    {{ page }}
                </Button>

                

                <Button variant="outline" size="icon" :disabled="currentPage === totalPages"
                    @click="goToPage(currentPage + 1)">
                    <ChevronRight class="h-4 w-4" />
                </Button>
            </div>
        </div>
    </div>
</template>