<template>
    <div class="weather-component">
        <h1>上市公司每月營業收入彙總表 </h1>
        <div>
            <h1>輸入以取得特定公司代碼相關資料</h1>
            <input v-model="companyCode" placeholder="公司代碼" />
            <button @click="getCompanyData">取得資料</button>
            <div>{{ companyCode }}</div>
        </div>

        <div v-if="loading" class="loading">
            Loading... 
        </div>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>出表日期</th>
                        <th>資料年月</th>
                        <th>公司代號</th>
                        <th>公司名稱</th>
                        <th>產業別</th>
                        <th>營業收入-當月營收</th>
                        <th>營業收入-上月營收</th>
                        <th>營業收入-去年當月營收</th>
                        <th>營業收入-上月比較增減(%)</th>
                        <th>營業收入-去年同月增減(%)</th>
                        <th>累計營業收入-當月累計營收</th>
                        <th>累計營業收入-去年累計營收</th>
                        <th>累計營業收入-前期比較增減(%)</th>
                        <th>備註</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="record in post" :key="record.reportDate">
                        <td>{{ record.reportDate }}</td>
                        <td>{{ record.dataYearMonth }}</td>
                        <td>{{ record.companyCode }}</td>
                        <td>{{ record.companyName }}</td>
                        <td>{{ record.industry }}</td>
                        <td>{{ record.currentMonthRevenue }}</td>
                        <td>{{ record.previousMonthRevenue }}</td>
                        <td>{{ record.lastYearSameMonthRevenue }}</td>
                        <td>{{ record.monthComparisonPercentage }}</td>
                        <td>{{ record.yearComparisonPercentage }}</td>
                        <td>{{ record.cumulativeCurrentYearRevenue }}</td>
                        <td>{{ record.cumulativeLastYearRevenue }}</td>
                        <td>{{ record.cumulativeComparisonPercentage }}</td>
                        <td>{{ record.notes }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import { ref, defineComponent } from 'vue';

    type MonthlyRevenues = {
        recordNumber: string,
        reportDate: string,
        dataYearMonth: string,
        companyCode: string,
        companyName: string,
        industry: string,
        currentMonthRevenue: string,
        previousMonthRevenue: string,
        lastYearSameMonthRevenue: string,
        monthComparisonPercentage: string,
        yearComparisonPercentage: string,
        cumulativeCurrentYearRevenue: string,
        cumulativeLastYearRevenue: string,
        cumulativeComparisonPercentage: string,
        notes: string
    }[];

    interface Data {
        loading: boolean,
        post: null | MonthlyRevenues
    }

    const companyCode = ref('')

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null,
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('api/monthlyrevenue')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as MonthlyRevenues;
                        this.loading = false;
                        return;
                    });
            },
            getCompanyData(): void {

                this.post = null;
                this.loading = true;

                fetch('api/monthlyrevenue/' + this.companyCode)
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as MonthlyRevenues;
                        this.loading = false;
                        return;
                    });

            }
        },
    });
</script>

<style scoped>
    th {
        font-weight: bold;
    }

    th, td {
        padding-left: .5rem;
        padding-right: .5rem;
    }

    .weather-component {
        text-align: center;
    }

    table {
        margin-left: auto;
        margin-right: auto;
    }
</style>